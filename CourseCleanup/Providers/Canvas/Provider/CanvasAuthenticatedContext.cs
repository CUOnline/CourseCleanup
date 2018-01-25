using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CourseCleanup.Web.Providers.Canvas.Provider
{
    /// <summary>
    /// Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.
    /// </summary>
    public class CanvasAuthenticatedContext : BaseContext
    {
        /// <summary>
        /// Initializes a <see cref="CanvasAuthenticatedContext"/>
        /// </summary>
        /// <param name="context">The OWIN environment</param>
        /// <param name="user">The JSON-serialized user</param>
        /// <param name="accessToken">Canvas Access token</param>
        /// <param name="refreshToken">Canvas Refresh token</param>
        /// <param name="instanceUrl">Canvas instance url</param>
        public CanvasAuthenticatedContext(IOwinContext context, JObject user, string email, string accessToken, string refreshToken)
            : base(context)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Id = TryGetValue(user, "id");
            UserName = TryGetValue(user, "name");
            Email = email;
        }

        /// <summary>
        /// Gets the Canvas ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the Canvas username
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the Canvas User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets the Canvas access token
        /// </summary>
        public string AccessToken { get; internal set; }

        /// <summary>
        /// Gets the Canvas refresh token
        /// </summary>
        public string RefreshToken { get; internal set; }

        /// <summary>
        /// Gets the Roles of the current Canvas user
        /// </summary>
        public List<string> Roles { get; internal set; }

        /// <summary>
        /// Gets the <see cref="ClaimsIdentity"/> representing the user
        /// </summary>
        public ClaimsIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }

        private static string TryGetValue(JObject user, string propertyName)
        {
            JToken value;
            return user != null && user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }
    }
}