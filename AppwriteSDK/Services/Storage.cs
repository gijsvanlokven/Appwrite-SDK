using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AppwriteSDK.Helpers;
using AppwriteSDK.Models;

namespace AppwriteSDK.Services
{
    public class Storage : Service
    {
        public Storage(Client client) : base(client)
        {
        }

        /// <summary>
        /// List Buckets Async
        /// <para>
        /// Get a list of all the storage buckets.
        /// You can use the query params to filter your results.
        /// </para>
        /// </summary>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="cursor"></param>
        /// <param name="cursorDirection"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListBucketsAsync(string search = "", int limit = 25, int offset = 0,
            string cursor = "", string cursorDirection = "", OrderType orderType = OrderType.Asc)
        {
            const string path = "/storage/buckets";

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
        /// Create Bucket Async
        /// <para>
        /// Create a new storage bucket.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="name"></param>
        /// <param name="permission"></param>
        /// <param name="read"></param>
        /// <param name="write"></param>
        /// <param name="enabled"></param>
        /// <param name="maximumFileSize"></param>
        /// <param name="allowedFileExtensions"></param>
        /// <param name="encryption"></param>
        /// <param name="antivirus"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateBucketAsync(string bucketId, string name, string permission,
            List<object> read = null, List<object> write = null, bool enabled = true, int? maximumFileSize = null,
            List<object> allowedFileExtensions = null, bool encryption = false, bool antivirus = false)
        {
            const string path = "/storage/buckets";

            var parameters = new Dictionary<string, object>()
            {
                { "bucketId", bucketId },
                { "name", name },
                { "permission", permission },
                { "read", read },
                { "write", write },
                { "enabled", enabled },
                { "maximumFileSize", maximumFileSize },
                { "allowedFileExtensions", allowedFileExtensions },
                { "encryption", encryption },
                { "antivirus", antivirus }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Bucket Async
        /// <para>
        /// Get a storage bucket by its unique ID.
        /// This endpoint response returns a JSON object with the storage bucket metadata.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetBucketAsync(string bucketId)
        {
            var path = $"/storage/buckets/{bucketId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Bucket Async
        /// <para>
        /// Update a storage bucket by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="name"></param>
        /// <param name="permission"></param>
        /// <param name="read"></param>
        /// <param name="write"></param>
        /// <param name="enabled"></param>
        /// <param name="maximumFileSize"></param>
        /// <param name="allowedFileExtensions"></param>
        /// <param name="encryption"></param>
        /// <param name="antivirus"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateBucketAsync(string bucketId, string name, string permission,
            List<object> read = null, List<object> write = null, bool enabled = true, int? maximumFileSize = null,
            List<object> allowedFileExtensions = null, bool encryption = false, bool antivirus = false)
        {
            var path = $"/storage/buckets/{bucketId}";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name },
                { "permission", permission },
                { "read", read },
                { "write", write },
                { "enabled", enabled },
                { "maximumFileSize", maximumFileSize },
                { "allowedFileExtensions", allowedFileExtensions },
                { "encryption", encryption },
                { "antivirus", antivirus }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Delete Bucket
        /// <para>
        /// Delete a storage bucket by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteBucketAsync(string bucketId)
        {
            var path = $"/storage/buckets/{bucketId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// List Files Async
        /// <para>
        /// Get a list of all the user files. You can use the query params to filter
        /// your results. On admin mode, this endpoint will return a list of all of the
        /// project's files. [Learn more about different API modes](/docs/admin).
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="cursor"></param>
        /// <param name="cursorDirection"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListFilesAsync(string bucketId, string search = "", int? limit = 25,
            int? offset = 0, string cursor = "", string cursorDirection = "", OrderType orderType = OrderType.Asc)
        {
            var path = $"/storage/buckets/{bucketId}/files";

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
        /// Create File Async
        /// <para>
        /// Create a new file. The user who creates the file will automatically be
        /// assigned to read and write access unless he has passed custom values for
        /// read and write arguments.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="fileId"></param>
        /// <param name="file"></param>
        /// <param name="read"></param>
        /// <param name="write"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateFileAsync(string bucketId, string fileId, FileInfo file,
            List<object> read = null, List<object> write = null)
        {
            var path = $"/storage/buckets/{bucketId}/files";

            var parameters = new Dictionary<string, object>()
            {
                { "fileId", fileId },
                { "file", file },
                { "read", read },
                { "write", write }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "multipart/form-data" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get File Async
        /// <para>
        /// Get a file by its unique ID. This endpoint response returns a JSON object
        /// with the file metadata.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetFileAsync(string bucketId, string fileId)
        {
            var path = $"/storage/buckets/{bucketId}/files/{fileId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update File Async
        /// <para>
        /// Update a file by its unique ID. Only users with write permissions have
        /// access to update this resource.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="fileId"></param>
        /// <param name="read"></param>
        /// <param name="write"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateFileAsync(string bucketId, string fileId, List<object> read = null,
            List<object> write = null)
        {
            var path = $"/storage/buckets/{bucketId}/files/{fileId}";

            var parameters = new Dictionary<string, object>()
            {
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
        /// Delete File Async
        /// <para>
        /// Delete a file by its unique ID. Only users with write permissions have
        /// access to delete this resource.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteFile(string bucketId, string fileId)
        {
            var path = $"/storage/buckets/{bucketId}/files/{fileId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Get File for Download
        /// <para>
        /// Get a file content by its unique ID. The endpoint response return with a
        /// 'Content-Disposition: attachment' header that tells the browser to start
        /// downloading the file to user downloads directory.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string GetFileDownload(string bucketId, string fileId)
        {
            var path = $"/storage/buckets/{bucketId}/files/{fileId}/download";

            var parameters = new Dictionary<string, object>();

            return Client.GetEndPoint() + path + "?" + parameters.ToQueryString();
        }

        /// <summary>
        /// Get File Preview
        /// <para>
        /// Get a file preview image. Currently, this method supports preview for image
        /// files (jpg, png, and gif), other supported formats, like pdf, docs, slides,
        /// and spreadsheets, will return the file icon image. You can also pass query
        /// string arguments for cutting and resizing your preview image.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="fileId"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="gravity"></param>
        /// <param name="quality"></param>
        /// <param name="borderWidth"></param>
        /// <param name="borderColor"></param>
        /// <param name="borderRadius"></param>
        /// <param name="opacity"></param>
        /// <param name="rotation"></param>
        /// <param name="background"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public string GetFilePreview(string bucketId, string fileId, int? width = 0, int? height = 0,
            string gravity = "center",
            int? quality = 100, int? borderWidth = 0, string borderColor = "", int? borderRadius = 0, int? opacity = 0,
            int? rotation = 0, string background = "", string output = "")
        {
            var path = $"/storage/buckets/{bucketId}/files/{fileId}/preview";

            var parameters = new Dictionary<string, object>()
            {
                { "width", width },
                { "height", height },
                { "gravity", gravity },
                { "quality", quality },
                { "borderWidth", borderWidth },
                { "borderColor", borderColor },
                { "borderRadius", borderRadius },
                { "opacity", opacity },
                { "rotation", rotation },
                { "background", background },
                { "output", output }
            };

            return Client.GetEndPoint() + path + "?" + parameters.ToQueryString();
        }

        /// <summary>
        /// Get File for View
        /// <para>
        /// Get a file content by its unique ID. This endpoint is similar to the
        /// download method but returns with no  'Content-Disposition: attachment'
        /// header.
        /// </para>
        /// </summary>
        /// <param name="bucketId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string GetFileView(string bucketId, string fileId)
        {
            var path = $"/storage/buckets/{bucketId}/files/{fileId}/view";

            var parameters = new Dictionary<string, object>();

            return Client.GetEndPoint() + path + "?" + parameters.ToQueryString();
        }

        /// <summary>
        /// Get Usage Stats For Storage Async
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetStorageUsageStatsAsync()
        {
            const string path = "/storage/usage";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Bucket Usage Stats Async
        /// </summary>
        /// <param name="bucketId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetBucketUsageStatsAsync(string bucketId)
        {
            var path = $"/storage/{bucketId}/usage";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }
    };
}