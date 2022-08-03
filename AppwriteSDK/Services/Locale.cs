using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Appwrite;

namespace AppwriteSDK.Services
{
    public class Locale : Service
    {
        public Locale(Client client) : base(client)
        {
        }

        /// <summary>
        /// Get User Locale Async
        /// <para>
        /// Get the current user location based on IP. Returns an object with user
        /// country code, country name, continent name, continent code, ip address and
        /// suggested currency. You can use the locale header to get the data in a
        /// supported language.
        /// 
        /// ([IP Geolocation by DB-IP](https://db-ip.com))
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetLocaleAsync()
        {
            const string path = "/locale";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List Continents Async
        /// <para>
        /// List of all continents. You can use the locale header to get the data in a
        /// supported language.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetContinentsAsync()
        {
            const string path = "/locale/continents";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List Countries Async
        /// <para>
        /// List of all countries. You can use the locale header to get the data in a
        /// supported language.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetCountriesAsync()
        {
            const string path = "/locale/countries";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List EU Countries Async
        /// <para>
        /// List of all countries that are currently members of the EU. You can use the
        /// locale header to get the data in a supported language.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetCountriesEuAsync()
        {
            const string path = "/locale/countries/eu";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List Countries Phone Codes Async
        /// <para>
        /// List of all countries phone codes. You can use the locale header to get the
        /// data in a supported language.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetCountriesPhonesAsync()
        {
            const string path = "/locale/countries/phones";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List Currencies Async
        /// <para>
        /// List of all currencies, including currency symbol, name, plural, and
        /// decimal digits for all major and minor currencies. You can use the locale
        /// header to get the data in a supported language.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetCurrenciesAsync()
        {
            const string path = "/locale/currencies";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List Languages Async
        /// <para>
        /// List of all languages classified by ISO 639-1 including 2-letter code, name
        /// in English, and name in the respective language.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetLanguagesAsync()
        {
            const string path = "/locale/languages";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}