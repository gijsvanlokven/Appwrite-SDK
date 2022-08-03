using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Appwrite;

namespace AppwriteSDK.Services
{
    public class Health : Service
    {
        public Health(Client client) : base(client)
        {
        }

        /// <summary>
        /// Get HTTP Async
        /// <para>
        /// Check the Appwrite HTTP server is up and responsive.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetAsync()
        {
            const string path = "/health";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Antivirus Async
        /// <para>
        /// Check the Appwrite Antivirus server is up and connection is successful.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetAntivirusAsync()
        {
            const string path = "/health/anti-virus";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Cache Async
        /// <para>
        /// Check the Appwrite in-memory cache server is up and connection is
        /// successful.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetCacheAsync()
        {
            const string path = "/health/cache";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get DB Async
        /// <para>
        /// Check the Appwrite database server is up and connection is successful.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetDbAsync()
        {
            const string path = "/health/db";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Certificates Queue Async
        /// <para>
        /// Get the number of certificates that are waiting to be issued against
        /// [Letsencrypt](https://letsencrypt.org/) in the Appwrite internal queue
        /// server.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetQueueCertificatesAsync()
        {
            const string path = "/health/queue/certificates";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Functions Queue Async
        /// </summary>
        public async Task<HttpResponseMessage> GetQueueFunctionsAsync()
        {
            const string path = "/health/queue/functions";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Logs Queue Async
        /// <para>
        /// Get the number of logs that are waiting to be processed in the Appwrite
        /// internal queue server.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetQueueLogsAsync()
        {
            const string path = "/health/queue/logs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
        
        /// <summary>
        /// Get Webhooks Queue Async
        /// <para>
        /// Get the number of webhooks that are waiting to be processed in the Appwrite
        /// internal queue server.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetQueueWebhooksAsync()
        {
            const string path = "/health/queue/webhooks";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
        
        /// <summary>
        /// Get Local Storage Async
        /// <para>
        /// Check the Appwrite local storage device is up and connection is successful.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetStorageLocalAsync()
        {
            const string path = "/health/storage/local";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
        
        /// <summary>
        /// Get Time Async
        /// <para>
        /// Check the Appwrite server time is synced with Google remote NTP server. We
        /// use this technology to smoothly handle leap seconds with no disruptive
        /// events. The [Network Time
        /// Protocol](https://en.wikipedia.org/wiki/Network_Time_Protocol) (NTP) is
        /// used by hundreds of millions of computers and devices to synchronize their
        /// clocks over the Internet. If your computer sets its own clock, it likely
        /// uses NTP.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetTimeAsync()
        {
            const string path = "/health/time";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
        
    };
}