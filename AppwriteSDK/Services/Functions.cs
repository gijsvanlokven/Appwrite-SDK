using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AppwriteSDK.Models;

namespace AppwriteSDK.Services
{
    public class Functions : Service
    {
        public Functions(Client client) : base(client)
        {
        }

        /// <summary>
        /// List Functions Async
        /// <para>
        /// Get a list of all the project's functions. You can use the query params to
        /// filter your results.
        /// </para>
        /// </summary>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="cursor"></param>
        /// <param name="cursorDirection"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListAsync(string search = "", int? limit = 25, int? offset = 0,
            string cursor = "", string cursorDirection = "", OrderType orderType = OrderType.Asc)
        {
            const string path = "/functions";

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
        /// Create Function Async
        /// <para>
        /// Create a new function. You can pass a list of
        /// [permissions](/docs/permissions) to allow different project users or team
        /// with access to execute the function using the client API.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="name"></param>
        /// <param name="execute"></param>
        /// <param name="runtime"></param>
        /// <param name="vars"></param>
        /// <param name="events"></param>
        /// <param name="schedule"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateAsync(string functionId, string name, List<object> execute,
            string runtime,
            object vars = null, List<object> events = null, string schedule = "", int? timeout = 15)
        {
            const string path = "/functions";

            var parameters = new Dictionary<string, object>()
            {
                { "functionId", functionId },
                { "name", name },
                { "execute", execute },
                { "runtime", runtime },
                { "vars", vars },
                { "events", events },
                { "schedule", schedule },
                { "timeout", timeout }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// List Runtimes Async
        /// <para>
        /// Get a list of all runtimes that are currently active on your instance.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListRuntimesAsync()
        {
            const string path = "/functions/runtimes";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Function Async
        /// <para>
        /// Get a function by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string functionId)
        {
            var path = $"/functions/{functionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Function Async
        /// <para>
        /// Update function by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="name"></param>
        /// <param name="execute"></param>
        /// <param name="vars"></param>
        /// <param name="events"></param>
        /// <param name="schedule"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateAsync(string functionId, string name, List<object> execute,
            object vars = null, List<object> events = null, string schedule = "", int? timeout = 15)
        {
            var path = $"/functions/{functionId}";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name },
                { "execute", execute },
                { "vars", vars },
                { "events", events },
                { "schedule", schedule },
                { "timeout", timeout }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Delete Function Async
        /// <para>
        /// Delete a function by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteAsync(string functionId)
        {
            var path = $"/functions/{functionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// List Deployments Async
        /// <para>
        /// Get a list of all the project's code deployments.
        /// You can use the query params to filter your results.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="cursor"></param>
        /// <param name="cursorDirection"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListDeploymentsAsync(string functionId, string search = "",
            int? limit = 25, int? offset = 0, string cursor = "", string cursorDirection = "",
            OrderType orderType = OrderType.Asc)
        {
            var path = $"/functions/{functionId}/deployments";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Create Deployment Async
        /// <para>
        /// Create a new function code deployment. Use this endpoint to upload a new version of your code function.
        /// To execute your newly uploaded code, you'll need to update the
        /// function's deployment to use your new deployment UID.
        /// This endpoint accepts a tar.gz file compressed with your code.
        /// Make sure to include any dependencies your code has within the compressed file.
        /// You can learn more about code packaging in the [Appwrite Cloud Functions tutorial](https://appwrite.io/docs/functions).
        /// Use the "command" param to set the entry point used to execute your code.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="entrypoint"></param>
        /// <param name="code"></param>
        /// <param name="activate"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateDeploymentAsync(string functionId, string entrypoint,
            FileInfo code, bool activate)
        {
            var path = $"/functions/{functionId}/deployments";

            var parameters = new Dictionary<string, object>
            {
                { "entrypoint", entrypoint },
                { "code", code },
                { "activate", activate }
            };

            var headers = new Dictionary<string, string>
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        ///     Get Deployment Async
        ///     <para>
        ///         Get a code deployment by its unique ID.
        ///     </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="deploymentId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetDeploymentAsync(string functionId, string deploymentId)
        {
            var path = $"/functions/{functionId}/deployments/{deploymentId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Deployment Async
        /// <para>
        /// Update the function code deployment ID using the unique function ID.
        /// Use this endpoint to switch the code deployment that should be executed by the execution endpoint.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="deploymentId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateDeploymentAsync(string functionId, string deploymentId)
        {
            var path = $"/functions/{functionId}/deployments/{deploymentId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        ///     Delete Deployment Async
        ///     <para>
        ///         Delete a code deployment by its unique ID.
        ///     </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="deploymentId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteDeploymentAsync(string functionId, string deploymentId)
        {
            var path = $"/functions/{functionId}/deployments/{deploymentId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        ///     Retry Build Async
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="deploymentId"></param>
        /// <param name="buildId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RetryBuildAsync(string functionId, string deploymentId, string buildId)
        {
            var path = $"/functions/{functionId}/deployments/{deploymentId}/builds/{buildId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        ///     List Executions Async
        ///     <para>
        ///         Get a list of all the current user function execution logs. You can use the
        ///         query params to filter your results. On admin mode, this endpoint will
        ///         return a list of all of the project's executions. [Learn more about
        ///         different API modes](/docs/admin).
        ///     </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="cursor"></param>
        /// <param name="cursorDirection"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ListExecutionsAsync(string functionId, string search = "",
            int? limit = 25,
            int? offset = 0, string cursor = "", string cursorDirection = "", OrderType orderType = OrderType.Asc)
        {
            var path = $"/functions/{functionId}/executions";

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
        /// Create Execution Async
        /// <para>
        /// Trigger a function execution. The returned object will return you the
        /// current execution status. You can ping the `Get Execution` endpoint to get
        /// updates on the current execution status. Once this endpoint is called, your
        /// function execution process will start asynchronously.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="data"></param>
        /// <param name="async"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateExecutionAsync(string functionId, string data = "",
            bool async = false)
        {
            var path = $"/functions/{functionId}/executions";

            var parameters = new Dictionary<string, object>()
            {
                { "data", data },
                { "async", async }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Execution
        /// <para>
        /// Get a function execution log by its unique ID.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetExecution(string functionId, string executionId)
        {
            var path = "/functions/{functionId}/executions/{executionId}".Replace("{functionId}", functionId)
                .Replace("{executionId}", executionId);

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Execution Async
        /// <para>
        /// Get a function execution log by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="executionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetExecutionAsync(string functionId, string executionId)
        {
            var path = $"/functions/{functionId}/executions/{executionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Function Usage Async
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetFunctionUsageAsync(string functionId, string range = "30d")
        {
            var path = $"/functions/{functionId}/usage";

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
    };
}