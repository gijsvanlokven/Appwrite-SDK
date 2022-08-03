using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppwriteSDK.Services
{
    public class Account : Service
    {
        public Account(Client client) : base(client)
        {
        }

        /// <summary>
        /// Get Account Async
        /// <para>
        /// Get currently logged in user data as JSON object.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetAsync()
        {
            const string path = "/account";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Account Email Async
        /// <para>
        /// Update currently logged in user account email address. After changing user
        /// address, user confirmation status is being reset and a new confirmation
        /// mail is sent. For security measures, user password is required to complete
        /// this request.
        /// This endpoint can also be used to convert an anonymous account to a normal
        /// one, by passing an email address and a new password.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateEmailAsync(string email, string password)
        {
            const string path = "/account/email";

            var parameters = new Dictionary<string, object>
            {
                { "email", email },
                { "password", password }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Get Account Logs Async
        /// <para>
        /// Get currently logged in user list of latest security activity logs. Each
        /// log returns user IP address, location and date and time of log.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetLogsAsync()
        {
            const string path = "/account/logs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Account Password Async
        /// <para>
        /// Update currently logged in user password. For validation, user is required
        /// to pass in the new password, and the old password. For users created with
        /// OAuth and Team Invites, oldPassword is optional.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdatePasswordAsync(string password, string oldPassword = "")
        {
            const string path = "/account/password";

            var parameters = new Dictionary<string, object>()
            {
                { "password", password },
                { "oldPassword", oldPassword }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Update Account Name Async
        /// <para>
        /// Update currently logged in user account name.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateNameAsync(string name)
        {
            const string path = "/account/name";

            var parameters = new Dictionary<string, object>()
            {
                { "name", name }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Get Account Preferences Async
        /// <para>
        /// Get currently logged in user preferences as a key-value object.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetPrefsAsync()
        {
            const string path = "/account/prefs";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Update Account Preferences Async
        /// <para>
        /// Update currently logged in user account preferences. You can pass only the
        /// specific settings you wish to update.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdatePrefsAsync(object prefs)
        {
            const string path = "/account/prefs";

            var parameters = new Dictionary<string, object>()
            {
                { "prefs", prefs }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Create Password Recovery Async
        /// <para>
        /// Sends the user an email with a temporary secret key for password reset.
        /// When the user clicks the confirmation link he is redirected back to your
        /// app password reset URL with the secret key and email address values
        /// attached to the URL query string. Use the query string params to submit a
        /// request to the [PUT
        /// /account/recovery](/docs/client/account#accountUpdateRecovery) endpoint to
        /// complete the process. The verification link sent to the user's email
        /// address is valid for 1 hour.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateRecoveryAsync(string email, string url)
        {
            const string path = "/account/recovery";

            var parameters = new Dictionary<string, object>()
            {
                { "email", email },
                { "url", url }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Complete Password Recovery Async
        /// <para>
        /// Use this endpoint to complete the user account password reset. Both the
        /// **userId** and **secret** arguments will be passed as query parameters to
        /// the redirect URL you have provided when sending your request to the [POST
        /// /account/recovery](/docs/client/account#accountCreateRecovery) endpoint.
        /// 
        /// Please note that in order to avoid a [Redirect
        /// Attack](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.md)
        /// the only valid redirect URLs are the ones from domains you have set when
        /// adding your platforms in the console interface.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateRecoveryAsync(string userId, string secret, string password,
            string passwordAgain)
        {
            const string path = "/account/recovery";

            var parameters = new Dictionary<string, object>()
            {
                { "userId", userId },
                { "secret", secret },
                { "password", password },
                { "passwordAgain", passwordAgain }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Get Account Sessions Async
        /// <para>
        /// Get currently logged in user list of active sessions across different
        /// devices.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetSessionsAsync()
        {
            const string path = "/account/sessions";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Delete All Account Sessions Async
        /// <para>
        /// Delete all sessions from the user account and remove any sessions cookies
        /// from the end client.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteSessionsAsync()
        {
            const string path = "/account/sessions";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Get Session By ID Async
        /// <para>
        /// Use this endpoint to get a logged in user's session using a Session ID.
        /// Inputting 'current' will return the current session being used.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetSessionAsync(string sessionId)
        {
            var path = "/account/sessions/{sessionId}".Replace("{sessionId}", sessionId);

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Delete Account Session Async
        /// <para>
        /// Use this endpoint to log out the currently logged in user from all their
        /// account sessions across all of their different devices. When using the
        /// option id argument, only the session unique ID provider will be deleted.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteSessionAsync(string sessionId)
        {
            var path = "/account/sessions/{sessionId}".Replace("{sessionId}", sessionId);

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Update Account Status Async
        /// <para>
        /// Block the currently logged in user account. Behind the scene, the user record
        /// is not deleted but permanently blocked from any access.
        /// To completely delete a user, use the Users API instead.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateAccountStatusAsync()
        {
            const string path = "/account/status";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PATCH", path, headers, parameters);
        }

        /// <summary>
        /// Create Email Verification Async
        /// <para>
        /// Use this endpoint to send a verification message to your user email address
        /// to confirm they are the valid owners of that address. Both the **userId**
        /// and **secret** arguments will be passed as query parameters to the URL you
        /// have provided to be attached to the verification email. The provided URL
        /// should redirect the user back to your app and allow you to complete the
        /// verification process by verifying both the **userId** and **secret**
        /// parameters. Learn more about how to [complete the verification
        /// process](/docs/client/account#accountUpdateVerification). The verification
        /// link sent to the user's email address is valid for 7 days.
        /// 
        /// Please note that in order to avoid a [Redirect
        /// Attack](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.md),
        /// the only valid redirect URLs are the ones from domains you have set when
        /// adding your platforms in the console interface.
        /// 
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateVerificationAsync(string url)
        {
            const string path = "/account/verification";

            var parameters = new Dictionary<string, object>()
            {
                { "url", url }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Complete Email Verification Async
        /// <para>
        /// Use this endpoint to complete the user email verification process. Use both
        /// the **userId** and **secret** parameters that were attached to your app URL
        /// to verify the user email ownership. If confirmed this route will return a
        /// 200 status code.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateVerificationAsync(string userId, string secret)
        {
            const string path = "/account/verification";

            var parameters = new Dictionary<string, object>()
            {
                { "userId", userId },
                { "secret", secret }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PUT", path, headers, parameters);
        }

        /// <summary>
        /// Create Phone Verification Async
        /// <para>
        /// Use this endpoint to send a verification SMS to the currently logged in user.
        /// This endpoint is meant for use after updating a user's phone number using the
        /// accountUpdatePhone endpoint. Learn more about how to complete the verification process.
        /// The verification code sent to the user's phone number is valid for 15 minutes.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreatePhoneVerificationAsync()
        {
            const string path = "/account/verification/phone";

            var parameters = new Dictionary<string, object>();

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Complete Phone Verification Async
        /// <para>
        /// Use this endpoint to complete the user phone verification process.
        /// Use the userId and secret that were sent to your user's phone number to
        /// verify the user email ownership. If confirmed this route will return a 200 status code.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdatePhoneVerificationAsync(string userId, string secret)
        {
            const string path = "/account/verification/phone";

            var parameters = new Dictionary<string, object>()
            {
                { "userId", userId },
                { "secret", secret }
            };

            var headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await Client.Call("PUT", path, headers, parameters);
        }
    };
}