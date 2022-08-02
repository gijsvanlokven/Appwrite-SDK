using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppwriteSDK.Helpers;
using AppwriteSDK.Models;
using Newtonsoft.Json.Linq;

namespace AppwriteSDK
{
    public class Client
    {
        private readonly Dictionary<string, string> _config;
        private readonly Dictionary<string, string> _headers;
        private readonly HttpClient _http;
        private string _endPoint;
        private bool _selfSigned;

        public Client() : this("https://appwrite.io/v1", false, new HttpClient())
        {
        }

        private Client(string endPoint, bool selfSigned, HttpClient http)
        {
            this._endPoint = endPoint;
            this._selfSigned = selfSigned;
            this._headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" },
                { "x-sdk-version", "appwrite:dotnet:0.3.0" },
                { "X-Appwrite-Response-Format", "0.9.0" }
            };
            this._config = new Dictionary<string, string>();
            this._http = http;
        }

        public Client SetSelfSigned(bool selfSigned)
        {
            this._selfSigned = selfSigned;
            return this;
        }

        public Client SetEndPoint(string endPoint)
        {
            this._endPoint = endPoint;
            return this;
        }

        public string GetEndPoint()
        {
            return _endPoint;
        }

        public Dictionary<string, string> GetConfig()
        {
            return _config;
        }

        /// <summary>Your project ID</summary>
        public Client SetProject(string value)
        {
            _config.Add("project", value);
            AddHeader("X-Appwrite-Project", value);
            return this;
        }

        /// <summary>Your secret API key</summary>
        public Client SetKey(string value)
        {
            _config.Add("key", value);
            AddHeader("X-Appwrite-Key", value);
            return this;
        }

        /// <summary>Your secret JSON Web Token</summary>
        public Client SetJwt(string value)
        {
            _config.Add("jWT", value);
            AddHeader("X-Appwrite-JWT", value);
            return this;
        }

        public Client SetLocale(string value)
        {
            _config.Add("locale", value);
            AddHeader("X-Appwrite-Locale", value);
            return this;
        }

        private void AddHeader(string key, string value)
        {
            _headers.Add(key, value);
        }

        public async Task<HttpResponseMessage> Call(string method, string path, Dictionary<string, string> headers,
            Dictionary<string, object> parameters)
        {
            if (_selfSigned)
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;
            }

            var methodGet = "GET".Equals(value: method, comparisonType: StringComparison.InvariantCultureIgnoreCase);

            var queryString = methodGet ? "?" + parameters.ToQueryString() : string.Empty;

            var request = new HttpRequestMessage(method: new HttpMethod(method: method),
                requestUri: _endPoint + path + queryString);

            if ("multipart/form-data".Equals(value: headers[key: "content-type"],
                    comparisonType: StringComparison.InvariantCultureIgnoreCase))
            {
                var form = new MultipartFormDataContent();

                foreach (var parameter in parameters)
                {
                    if (parameter.Key == "file")
                    {
                        if (parameters[key: "file"] is not FileInfo fi) continue;
                        var file = await File.ReadAllBytesAsync(path: fi.FullName);

                        form.Add(content: new ByteArrayContent(content: file, offset: 0, count: file.Length),
                            name: "file", fileName: fi.Name);
                    }
                    else if (parameter.Value is IEnumerable<object> value)
                    {
                        var list = new List<object>(collection: value);
                        for (var index = 0; index < list.Count; index++)
                        {
                            form.Add(
                                content: new StringContent(content: list[index: index].ToString() ??
                                                                    throw new InvalidOperationException()),
                                name: $"{parameter.Key}[{index}]");
                        }
                    }
                    else
                    {
                        form.Add(
                            content: new StringContent(content: parameter.Value.ToString() ??
                                                                throw new InvalidOperationException()),
                            name: parameter.Key);
                    }
                }

                request.Content = form;
            }
            else if (!methodGet)
            {
                string body = parameters.ToJson();

                request.Content =
                    new StringContent(content: body, encoding: Encoding.UTF8, mediaType: "application/json");
            }

            foreach (var header in this._headers)
            {
                if (header.Key.Equals(value: "content-type",
                        comparisonType: StringComparison.InvariantCultureIgnoreCase))
                {
                    _http.DefaultRequestHeaders.Accept.Add(
                        item: new MediaTypeWithQualityHeaderValue(mediaType: header.Value));
                }
                else
                {
                    if (_http.DefaultRequestHeaders.Contains(name: header.Key))
                    {
                        _http.DefaultRequestHeaders.Remove(name: header.Key);
                    }

                    _http.DefaultRequestHeaders.Add(name: header.Key, value: header.Value);
                }
            }

            foreach (var header in headers)
            {
                if (header.Key.Equals(value: "content-type",
                        comparisonType: StringComparison.InvariantCultureIgnoreCase))
                {
                    request.Headers.Accept.Add(item: new MediaTypeWithQualityHeaderValue(mediaType: header.Value));
                }
                else
                {
                    if (request.Headers.Contains(name: header.Key))
                    {
                        request.Headers.Remove(name: header.Key);
                    }

                    request.Headers.Add(name: header.Key, value: header.Value);
                }
            }

            try
            {
                var httpResponseMessage = await _http.SendAsync(request: request);
                var code = (int)httpResponseMessage.StatusCode;
                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                if (code < 400) return httpResponseMessage;
                var message = response;
                var isJson =
                    httpResponseMessage.Content.Headers.GetValues(name: "Content-Type").FirstOrDefault()!.Contains(
                        value: "application/json");

                if (!isJson) throw new AppwriteException(message: message, code: code, response: response);
                message = (JObject.Parse(json: message))[propertyName: "message"]?.ToString();
                throw new AppwriteException(message: message, code: code, response: response);
            }
            catch (Exception e)
            {
                throw new AppwriteException(message: e.Message, inner: e);
            }
        }
    }
}