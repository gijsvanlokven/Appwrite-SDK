using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Appwrite;
using AppwriteSDK.Models;

namespace AppwriteSDK.Services
{
    public class Users : Service
    {
        public Users(Client client) : base(client)
        {
        }

        /// <summary>
        /// List Users Async
        /// <para>
        /// Get a list of all the project's users. You can use the query params to
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
            const string path = "/users";

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
        /// Create User Async
        /// <para>
        /// Create a new user.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateAsync(string userId, string email, string password,
            string name = "")
        {
            const string path = "/users";

            var parameters = new Dictionary<string, object>()
            {
                { "userId", userId },
                { "email", email },
                { "password", password },
                { "name", name }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }


        /// <summary>
        /// Get Users Usage Async
        /// <para>
        /// Get usage stats for the users API
        /// </para>
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetUsageAsync()
        {
            const string path = "/users/usage";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get User Async
        /// <para>
        /// Get a user by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string userId)
        {
            var path = $"/users/{userId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Delete User Async
        /// <para>
        /// Delete a user by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteAsync(string userId)
        {
            var path = $"/users/{userId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Update Email Async
        /// <para>
        /// Update the user email by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateEmailAsync(string userId, string email)
        {
            var path = $"/users/{userId}/email";

            var parameters = new Dictionary<string, object>()
            {
                { "email", email }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Get User Logs Async
        /// <para>
        /// Get a user activity logs list by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetLogsAsync(string userId)
        {
            var path = $"/users/{userId}/logs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get User Memberships Async
        /// <para>
        /// Get the user membership list by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetMembershipsAsync(string userId)
        {
            var path = $"/users/{userId}/memberships";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Name Async
        /// <para>
        /// Update the user name by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateNameAsync(string userId, string name)
        {
            var path = $"/users/{userId}/name";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Update Password Async
        /// <para>
        /// Update the user password by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdatePasswordAsync(string userId, string password)
        {
            var path = $"/users/{userId}/password";

            var parameters = new Dictionary<string, object>()
            {
                { "password", password }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Update Phone Async
        /// <para>
        /// Update the user phone by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdatePhoneAsync(string userId, string number)
        {
            var path = $"/users/{userId}/phone";

            var parameters = new Dictionary<string, object>()
            {
                { "number", number }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Get User Preferences Async
        /// <para>
        /// Get the user preferences by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetPrefsAsync(string userId)
        {
            var path = $"/users/{userId}/prefs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update User Preferences Async
        /// <para>
        /// Update the user preferences by its unique ID. You can pass only the
        /// specific settings you wish to update.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="prefs"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdatePrefsAsync(string userId, object prefs)
        {
            var path = $"/users/{userId}/prefs";

            var parameters = new Dictionary<string, object>()
            {
                { "prefs", prefs }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Get User Sessions Async
        /// <para>
        /// Get the user sessions list by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetSessionsAsync(string userId)
        {
            var path = $"/users/{userId}/sessions";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Delete User Sessions Async
        /// <para>
        /// Delete all user's sessions by using the user's unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteSessionsAsync(string userId)
        {
            var path = $"/users/{userId}/sessions";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Delete User Session Async
        /// <para>
        /// Delete a user sessions by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteSessionAsync(string userId, string sessionId)
        {
            var path = $"/users/{userId}/sessions/{sessionId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Update User Status Async
        /// <para>
        /// Update the user status by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateStatusAsync(string userId, bool status)
        {
            var path = $"/users/{userId}/status";

            var parameters = new Dictionary<string, object>()
            {
                { "status", status }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Update Email Verification Async
        /// <para>
        /// Update the user email verification status by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emailVerification"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateVerificationAsync(string userId, bool emailVerification)
        {
            var path = $"/users/{userId}/verification";

            var parameters = new Dictionary<string, object>()
            {
                { "emailVerification", emailVerification }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Update Phone Verification Async
        /// <para>
        /// Update the user phone verification status by its unique ID.
        /// </para>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phoneVerification"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdatePhoneVerificationAsync(string userId, bool phoneVerification)
        {
            var path = $"/users/{userId}/verification/phone";

            var parameters = new Dictionary<string, object>()
            {
                { "phoneVerification", phoneVerification }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }
    };
}