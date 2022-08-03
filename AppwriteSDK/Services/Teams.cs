using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Appwrite;
using AppwriteSDK.Models;

namespace AppwriteSDK.Services
{
    public class Teams : Service
    {
        public Teams(Client client) : base(client)
        {
        }

        /// <summary>
        /// List Teams Async
        /// <para>
        /// Get a list of all the current user teams. You can use the query params to
        /// filter your results. On admin mode, this endpoint will return a list of all
        /// of the project's teams. [Learn more about different API
        /// modes](/docs/admin).
        /// </para>s
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
            const string path = "/teams";

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
        /// Create Team Async
        /// <para>
        /// Create a new team. The user who creates the team will automatically be
        /// assigned as the owner of the team. The team owner can invite new members,
        /// who will be able add new owners and update or delete the team from your
        /// project.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateAsync(string teamId, string name, List<object> roles = null)
        {
            const string path = "/teams";

            var parameters = new Dictionary<string, object>()
            {
                { "teamId", teamId },
                { "name", name },
                { "roles", roles }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Team Async
        /// <para>
        /// Get a team by its unique ID. All team members have read access for this
        /// resource.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string teamId)
        {
            var path = $"/teams/{teamId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Team Async
        /// <para>
        /// Update a team by its unique ID. Only team owners have write access for this
        /// resource.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateAsync(string teamId, string name)
        {
            var path = $"/teams/{teamId}";

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
        /// Delete Team Async
        /// <para>
        /// Delete a team by its unique ID. Only team owners have write access for this
        /// resource.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteAsync(string teamId)
        {
            var path = $"/teams/{teamId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Get Team Logs Async
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetLogsAsync(string teamId)
        {
            var path = $"/teams/{teamId}/logs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Get Team Memberships Async
        /// <para>
        /// Get a team members by the team unique ID. All team members have read access
        /// for this list of resources.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="cursor"></param>
        /// <param name="cursorDirection"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetMembershipsAsync(string teamId, string search = "", int? limit = 25,
            int? offset = 0, string cursor = "", string cursorDirection = "", OrderType orderType = OrderType.Asc)
        {
            var path = $"/teams/{teamId}/memberships";

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
        /// Create Team Membership Async
        /// <para>
        /// Use this endpoint to invite a new member to join your team. An email with a
        /// link to join the team will be sent to the new member email address if the
        /// member doesn't exist in the project it will be created automatically.
        /// 
        /// Use the 'URL' parameter to redirect the user from the invitation email back
        /// to your app. When the user is redirected, use the [Update Team Membership
        /// Status](/docs/client/teams#teamsUpdateMembershipStatus) endpoint to allow
        /// the user to accept the invitation to the team.
        /// 
        /// Please note that in order to avoid a [Redirect Attacks]
        /// (https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.md)
        /// the only valid redirect URL's are the once from domains you have set when
        /// added your platforms in the console interface.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="email"></param>
        /// <param name="roles"></param>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateMembershipAsync(string teamId, string email, List<object> roles,
            string url, string name = "")
        {
            var path = $"/teams/{teamId}/memberships";

            var parameters = new Dictionary<string, object>()
            {
                { "email", email },
                { "name", name },
                { "roles", roles },
                { "url", url }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Get Team Membership
        /// <para>
        /// Get a team member by the membership unique id.
        /// All team members have read access for this resource.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetMembershipAsync(string teamId, string membershipId)
        {
            var path = $"/teams/{teamId}/memberships/{membershipId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Membership Roles
        /// <para>
        /// Modify the roles of a team member. Only team members with the owner role have access to this endpoint.
        /// Learn more about [roles and permissions](https://appwrite.io/docs/permissions).
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="membershipId"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateMembershipRolesAsync(string teamId, string membershipId,
            List<object> roles)
        {
            var path = $"/teams/{teamId}/memberships/{membershipId}";

            var parameters = new Dictionary<string, object>()
            {
                { "roles", roles }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Delete Team Membership Async
        /// <para>
        /// This endpoint allows a user to leave a team or for a team owner to delete
        /// the membership of any other team member. You can also use this endpoint to
        /// delete a user membership even if it is not accepted.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteMembershipAsync(string teamId, string membershipId)
        {
            var path = $"/teams/{teamId}/memberships/{membershipId}";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Update Team Membership Status Async
        /// <para>
        /// Use this endpoint to allow a user to accept an invitation to join a team
        /// after being redirected back to your app from the invitation email recieved
        /// by the user.
        /// </para>
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="membershipId"></param>
        /// <param name="userId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateMembershipStatusAsync(string teamId, string membershipId,
            string userId,
            string secret)
        {
            var path = $"/teams/{teamId}/memberships/{membershipId}/status";

            var parameters = new Dictionary<string, object>()
            {
                { "userId", userId },
                { "secret", secret }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PATCH", path, headers, parameters);
        }
    };
}