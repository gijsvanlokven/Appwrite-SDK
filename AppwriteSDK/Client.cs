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
            _endPoint = endPoint;
            _selfSigned = selfSigned;
            _headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" },
                { "x-sdk-version", "appwrite:dotnet:0.3.0" },
                { "X-Appwrite-Response-Format", "0.9.0" }
            };
            _config = new Dictionary<string, string>();
            _http = http;
        }

        public Client SetSelfSigned(bool selfSigned)
        {
            _selfSigned = selfSigned;
            return this;
        }

        public Client SetEndPoint(string endPoint)
        {
            _endPoint = endPoint;
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
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;

            var methodGet = "GET".Equals(method, StringComparison.InvariantCultureIgnoreCase);

            var queryString = methodGet ? "?" + parameters.ToQueryString() : string.Empty;

            var request = new HttpRequestMessage(new HttpMethod(method),
                _endPoint + path + queryString);

            if ("multipart/form-data".Equals(headers["content-type"],
                    StringComparison.InvariantCultureIgnoreCase))
            {
                var form = new MultipartFormDataContent();

                foreach (var parameter in parameters)
                    if (parameter.Key == "file")
                    {
                        if (parameters["file"] is not FileInfo fi) continue;
                        var file = await File.ReadAllBytesAsync(fi.FullName);

                        form.Add(new ByteArrayContent(file, 0, file.Length),
                            "file", fi.Name);
                    }
                    else if (parameter.Value is IEnumerable<object> value)
                    {
                        var list = new List<object>(value);
                        for (var index = 0; index < list.Count; index++)
                            form.Add(
                                new StringContent(list[index].ToString() ??
                                                  throw new InvalidOperationException()),
                                $"{parameter.Key}[{index}]");
                    }
                    else
                    {
                        form.Add(
                            new StringContent(parameter.Value.ToString() ??
                                              throw new InvalidOperationException()),
                            parameter.Key);
                    }

                request.Content = form;
            }
            else if (!methodGet)
            {
                var body = parameters.ToJson();

                request.Content =
                    new StringContent(body, Encoding.UTF8, "application/json");
            }

            foreach (var header in _headers)
                if (header.Key.Equals("content-type",
                        StringComparison.InvariantCultureIgnoreCase))
                {
                    _http.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue(header.Value));
                }
                else
                {
                    if (_http.DefaultRequestHeaders.Contains(header.Key))
                        _http.DefaultRequestHeaders.Remove(header.Key);

                    _http.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

            foreach (var header in headers)
                if (header.Key.Equals("content-type",
                        StringComparison.InvariantCultureIgnoreCase))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(header.Value));
                }
                else
                {
                    if (request.Headers.Contains(header.Key)) request.Headers.Remove(header.Key);

                    request.Headers.Add(header.Key, header.Value);
                }

            try
            {
                var httpResponseMessage = await _http.SendAsync(request);
                var code = (int)httpResponseMessage.StatusCode;
                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                if (code < 400) return httpResponseMessage;
                var message = response;
                var isJson =
                    httpResponseMessage.Content.Headers.GetValues("Content-Type").FirstOrDefault()!.Contains(
                        "application/json");

                if (!isJson) throw new AppwriteException(message, code, response);
                message = JObject.Parse(message)["message"]?.ToString();
                throw new AppwriteException(message, code, response);
            }
            catch (Exception e)
            {
                throw new AppwriteException(e.Message, e);
            }
        }
    }
}