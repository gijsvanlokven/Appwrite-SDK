using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppwriteSDK.Models;

namespace AppwriteSDK.Services
{
    public class Databases : Service
    {
        private readonly string _databaseId;

        public Databases(Client client, string databaseId) : base(client)
        {
            _databaseId = databaseId;
        }

        /// <summary>
        /// List Databases Async
        /// </summary>
        /// <para>
        /// Get a list of all databases from the current Appwrite project.
        /// You can use the search parameter to filter your results.
        /// </para>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="cursor"></param>
        /// <param name="cursorDirection"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListDatabasesAsync(string search = "", int? limit = 25, int? offset = 0,
            string cursor = "", string cursorDirection = "", OrderType orderType = OrderType.Asc)
        {
            const string path = "/databases";

            var parameters = new Dictionary<string, object>()
            {
                { "search", search },
                { "limit", limit },
                { "offset", offset },
                { "cursor", cursor },
                { "cursorDirection", cursorDirection },
                { "orderType", orderType.ToString() }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Database Async
        /// </summary>
        /// <para>
        /// Create a new Database
        /// </para>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateDatabaseAsync(string name)
        {
            const string path = "/databases";

            var parameters = new Dictionary<string, object>()
            {
                { "databaseId", _databaseId },
                { "name", name }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get usage stats for the databases async
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetDatabasesUsageAsync(string range = "")
        {
            const string path = "/databases/usage";

            var parameters = new Dictionary<string, object>()
            {
                { "range", range }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Database async
        /// </summary>
        /// <para>
        /// Get a database by its unique ID. This endpoint response returns
        /// a JSON object with the database metadata.
        /// </para>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetDatabaseAsync()
        {
            var path = $"/databases/{_databaseId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Database Async
        /// </summary>
        /// <para>
        /// Update a database by its unique ID.
        /// </para>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateDatabaseAsync(string name)
        {
            var path = $"/databases/{_databaseId}";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Delete Database Async
        /// </summary>
        /// <para>
        /// Delete a database by its unique ID.
        /// Only API keys with with databases.write scope can delete a database.
        /// </para>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteDatabaseAsync()
        {
            var path = $"/databases/{_databaseId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// List Collections Async
        /// <para>
        /// Get a list of all the user collections. You can use the query params to
        /// filter your results. On admin mode, this endpoint will return a list of all
        /// of the project's collections. [Learn more about different API
        /// modes](/docs/admin).
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> ListCollectionsAsync(string search = "",
            int? limit = 25, int? offset = 0, string cursor = "", string cursorDirection = "",
            OrderType orderType = OrderType.Asc)
        {
            var path = $"/databases/{_databaseId}/collections";

            var parameters = new Dictionary<string, object>()
            {
                { "search", search },
                { "limit", limit },
                { "offset", offset },
                { "cursor", cursor },
                { "cursorDirection", cursorDirection },
                { "orderType", orderType.ToString() }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Collection Async
        /// <para>
        /// Create a new Collection.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateCollectionAsync(string collectionId,
            string name, string permission, List<object> read, List<object> write)
        {
            var path = $"/databases/{_databaseId}/collections";

            var parameters = new Dictionary<string, object>()
            {
                { "collectionId", collectionId },
                { "name", name },
                { "permission", permission },
                { "read", read },
                { "write", write }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Collection Async
        /// <para>
        /// Get a collection by its unique ID. This endpoint response returns a JSON
        /// object with the collection metadata.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetCollectionAsync(string collectionId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Collection Async
        /// <para>
        /// Update a collection by its unique ID.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateCollectionAsync(string collectionId,
            string name, string permission, List<object> read = null, List<object> write = null)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name },
                { "permission", permission },
                { "read", read },
                { "write", write }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Delete Collection Async
        /// <para>
        /// Delete a collection by its unique ID. Only users with write permissions
        /// have access to delete this resource.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteCollectionAsync(string collectionId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// List Attributes Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListAttributes(string collectionId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Boolean Attribute Async
        /// </summary>
        /// <para>
        /// Create a boolean attribute
        /// </para>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateBooleanAttributeAsync(string collectionId,
            string key, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/boolean";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "required", required },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create Email Attribute Async
        /// </summary>
        /// <para>
        /// Create an email attribute
        /// </para>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateEmailAttributeAsync(string collectionId,
            string key, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/email";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "required", required },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create Enum Attribute Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="elements"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateEnumAttributeAsync(string collectionId,
            string key, string[] elements, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/enum";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "elements", elements },
                { "required", required },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create Float Attribute Async
        /// </summary>
        /// <para>
        /// Create a float attribute. Optionally, minimum and maximum values can be provided.
        /// </para>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateFloatAttributeAsync(string collectionId,
            string key, bool required, float? min = null, float? max = null, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/float";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "required", required },
                { "min", min },
                { "max", max },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create Integer Attribute Async
        /// </summary>
        /// <para>
        /// Create an integer attribute. Optionally, minimum and maximum values can be provided.
        /// </para>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateIntegerAttributeAsync(string collectionId,
            string key, bool required, int? min = null, int? max = null, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/integer";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "required", required },
                { "min", min },
                { "max", max },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create IP Attribute Async
        /// </summary>
        /// <para>
        /// Create IP address attribute.
        /// </para>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateIpAttributeAsync(string collectionId,
            string key, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/ip";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "required", required },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create String Attribute Async
        /// </summary>
        /// <para>
        /// Create a string attribute.
        /// </para>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateStringAttributeAsync(string collectionId,
            string key, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/string";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "required", required },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create URL Attribute Async
        /// </summary>
        /// <para>
        /// Create a URL attribute.
        /// </para>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateUrlAttributeAsync(string collectionId,
            string key, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/url";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "required", required },
                { "default", @default },
                { "array", array }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Attribute Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAttributeAsync(string collectionId, string key)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/{key}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Delete Attribute Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteAttributeAsync(string collectionId, string key)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/attributes/{key}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }


        /// <summary>
        /// List Documents Async
        /// <para>
        /// Get a list of all the user's documents in a given collection.
        /// You can use the query params to filter your results. On admin mode,
        /// this endpoint will return a list of all of documents belonging to
        /// the provided collectionId. Learn more about different API modes.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> ListDocumentsAsync(string collectionId, List<object> queries = null,
            int? limit = null, int? offset = null, string cursor = "", string cursorDirection = "",
            List<object> orderAttributes = null, List<object> orderTypes = null)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/documents";

            var parameters = new Dictionary<string, object>()
            {
                { "queries", queries },
                { "limit", limit },
                { "offset", offset },
                { "cursor", cursor },
                { "cursorDirection", cursorDirection },
                { "orderAttributes", orderAttributes },
                { "orderTypes", orderTypes }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Document Async
        /// <para>
        /// Create a new Document. Before using this route,
        /// you should create a new collection resource using
        /// either a server integration API or directly from your database console.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateDocumentAsync(string collectionId, string documentId, object data,
            List<object> read = null, List<object> write = null)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/documents";

            var parameters = new Dictionary<string, object>()
            {
                { "documentId", documentId },
                { "data", data },
                { "read", read },
                { "write", write }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Document Async
        /// <para>
        /// Get a document by its unique ID. This endpoint response returns
        /// a JSON object with the document data.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetDocumentAsync(string collectionId, string documentId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/documents/{documentId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Document Async
        /// <para>
        /// Update a document by its unique ID. Using the patch method
        /// you can pass only specific fields that will get updated.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateDocumentAsync(string collectionId, string documentId, object data,
            List<object> read = null, List<object> write = null)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/documents/{documentId}";

            var parameters = new Dictionary<string, object>()
            {
                { "data", data },
                { "read", read },
                { "write", write }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Delete Document Async
        /// <para>
        /// Delete a document by its unique ID.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteDocumentAsync(string collectionId, string documentId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/documents/{documentId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Get Document Logs Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetDocumentLogsAsync(string collectionId, string documentId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/documents/{documentId}/usage";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List Indexes Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListIndexesAsync(string collectionId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/indexes";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Index Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <param name="attributes"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateIndexAsync(string collectionId, string key, string type,
            List<object> attributes, List<object> orders = null)

        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/indexes";

            var parameters = new Dictionary<string, object>()
            {
                { "key", key },
                { "type", type },
                { "attributes", attributes },
                { "orders", orders }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Index Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetIndexAsync(string collectionId, string key)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/indexes/{key}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Delete Index Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteIndexAsync(string collectionId, string key)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/indexes/{key}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Get Collection Log Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetCollectionLogsAsync(string collectionId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/logs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Collection Usage Async
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetCollectionUsageAsync(string collectionId)
        {
            var path = $"/databases/{_databaseId}/collections/{collectionId}/usage";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// List Collection Logs Async
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListCollectionLogsAsync()
        {
            var path = $"/databases/{_databaseId}/logs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Database Usage Async
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetDatabaseUsageAsync()
        {
            var path = $"/databases/{_databaseId}/usage";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }
    };
}