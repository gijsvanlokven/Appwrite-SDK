using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Appwrite;
using AppwriteSDK.Models;

namespace AppwriteSDK.Services
{
    public class Database : Service
    {
        public Database(Client client) : base(client)
        {
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

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Database Async
        /// </summary>
        /// <para>
        /// Create a new Database
        /// </para>
        /// <param name="databaseId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateDatabaseAsync(string databaseId, string name)
        {
            const string path = "/databases";

            var parameters = new Dictionary<string, object>()
            {
                { "databaseId", databaseId },
                { "name", name }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get usage stats for the database async
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetDatabaseUsageAsync(string range = "")
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

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Database async
        /// </summary>
        /// <para>
        /// Get a database by its unique ID. This endpoint response returns
        /// a JSON object with the database metadata.
        /// </para>
        /// <param name="databaseId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetDatabaseAsync(string databaseId)
        {
            var path = $"/databases/{databaseId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Database Async
        /// </summary>
        /// <para>
        /// Update a database by its unique ID.
        /// </para>
        /// <param name="databaseId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateDatabaseAsync(string databaseId, string name)
        {
            var path = $"/databases/{databaseId}";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Delete Database Async
        /// </summary>
        /// <para>
        /// Delete a database by its unique ID.
        /// Only API keys with with databases.write scope can delete a database.
        /// </para>
        /// <param name="databaseId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteDatabaseAsync(string databaseId)
        {
            var path = $"/databases/{databaseId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
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
        public async Task<HttpResponseMessage> ListCollectionsAsync(string databaseId, string search = "",
            int? limit = 25, int? offset = 0, string cursor = "", string cursorDirection = "",
            OrderType orderType = OrderType.Asc)
        {
            var path = $"/databases/{databaseId}/collections";

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

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Collection Async
        /// <para>
        /// Create a new Collection.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateCollectionAsync(string databaseId, string collectionId,
            string name, string permission, List<object> read, List<object> write)
        {
            var path = $"/databases/{databaseId}/collections";

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

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Collection Async
        /// <para>
        /// Get a collection by its unique ID. This endpoint response returns a JSON
        /// object with the collection metadata.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetCollectionAsync(string databaseId, string collectionId)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Collection Async
        /// <para>
        /// Update a collection by its unique ID.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateCollectionAsync(string databaseId, string collectionId,
            string name, string permission, List<object> read = null, List<object> write = null)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name },
                { "permission", permission },
                { "read", read },
                { "write", write },
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Delete Collection Async
        /// <para>
        /// Delete a collection by its unique ID. Only users with write permissions
        /// have access to delete this resource.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteCollectionAsync(string databaseId, string collectionId)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// List Attributes Async
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListAttributes(string databaseId, string collectionId)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}/attributes";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Boolean Attribute Async
        /// </summary>
        /// <para>
        /// Create a boolean attribute
        /// </para>
        /// <param name="databaseId"></param>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateBooleanAttributeAsync(string databaseId, string collectionId,
            string key, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}/attributes/boolean";

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

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create Email Attribute Async
        /// </summary>
        /// <para>
        /// Create an email attribute
        /// </para>
        /// <param name="databaseId"></param>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateEmailAttributeAsync(string databaseId, string collectionId,
            string key, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}/attributes/email";

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

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create Enum Attribute Async
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="elements"></param>
        /// <param name="required"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateEnumAttributeAsync(string databaseId, string collectionId,
            string key, string[] elements, bool required, bool @default = false, bool array = false)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}/attributes/enum";

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

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Create Float Attribute Async
        /// </summary>
        /// <para>
        /// Create a float attribute. Optionally, minimum and maximum values can be provided.
        /// </para>
        /// <param name="databaseId"></param>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        /// <param name="required"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="default"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateFloatAttributeAsync(string databaseId, string collectionId,
            string key, bool required, float min = 0f, float max = 0f, bool @default = false, bool array = false)
        {
            var path = $"/databases/{databaseId}/collections/{collectionId}/attributes/float";

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

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// List Documents
        /// <para>
        /// Get a list of all the user documents. You can use the query params to
        /// filter your results. On admin mode, this endpoint will return a list of all
        /// of the project's documents. [Learn more about different API
        /// modes](/docs/admin).
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> ListDocuments(string collectionId, List<object> filters = null,
            int? limit = 25, int? offset = 0, string orderField = "", OrderType orderType = OrderType.Asc,
            string orderCast = "string", string search = "")
        {
            string path = "/database/collections/{collectionId}/documents".Replace("{collectionId}", collectionId);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "filters", filters },
                { "limit", limit },
                { "offset", offset },
                { "orderField", orderField },
                { "orderType", orderType.ToString() },
                { "orderCast", orderCast },
                { "search", search }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Document
        /// <para>
        /// Create a new Document. Before using this route, you should create a new
        /// collection resource using either a [server
        /// integration](/docs/server/database#databaseCreateCollection) API or
        /// directly from your database console.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateDocument(string collectionId, object data,
            List<object> read = null, List<object> write = null, string parentDocument = "", string parentProperty = "",
            string parentPropertyType = "assign")
        {
            string path = "/database/collections/{collectionId}/documents".Replace("{collectionId}", collectionId);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "data", data },
                { "read", read },
                { "write", write },
                { "parentDocument", parentDocument },
                { "parentProperty", parentProperty },
                { "parentPropertyType", parentPropertyType }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Document
        /// <para>
        /// Get a document by its unique ID. This endpoint response returns a JSON
        /// object with the document data.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetDocument(string collectionId, string documentId)
        {
            string path = "/database/collections/{collectionId}/documents/{documentId}"
                .Replace("{collectionId}", collectionId).Replace("{documentId}", documentId);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Document
        /// <para>
        /// Update a document by its unique ID. Using the patch method you can pass
        /// only specific fields that will get updated.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateDocument(string collectionId, string documentId, object data,
            List<object> read = null, List<object> write = null)
        {
            string path = "/database/collections/{collectionId}/documents/{documentId}"
                .Replace("{collectionId}", collectionId).Replace("{documentId}", documentId);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "data", data },
                { "read", read },
                { "write", write }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Delete Document
        /// <para>
        /// Delete a document by its unique ID. This endpoint deletes only the parent
        /// documents, its attributes and relations to other documents. Child documents
        /// **will not** be deleted.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteDocument(string collectionId, string documentId)
        {
            string path = "/database/collections/{collectionId}/documents/{documentId}"
                .Replace("{collectionId}", collectionId).Replace("{documentId}", documentId);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }
    };
}