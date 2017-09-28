using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using CourseCleanup.Web.Providers.Canvas.Provider;

namespace CourseCleanup.Web.Providers.Canvas
{
    public class CanvasAuthenticationOptions : AuthenticationOptions
    {
        public class CanvasAuthenticationEndpoints
        {
            /// <summary>
            /// Endpoint which is used to redirect users to request Canvas access
            /// </summary>
            public string AuthorizationEndpoint { get; set; }

            /// <summary>
            /// Endpoint which is used to exchange code for access token
            /// </summary>
            public string TokenEndpoint { get; set; }
        }

        private const string AuthorizationEndPoint = "";
        private const string TokenEndpoint = "";

        /// <summary>
        ///     Gets or sets the a pinned certificate validator to use to validate the endpoints used
        ///     in back channel communications belong to Canvas.
        /// </summary>
        /// <value>
        ///     The pinned certificate validator.
        /// </value>
        /// <remarks>
        ///     If this property is null then the default certificate checks are performed,
        ///     validating the subject name and if the signing chain is a trusted party.
        /// </remarks>
        public ICertificateValidator BackchannelCertificateValidator { get; set; }

        /// <summary>
        ///     The HttpMessageHandler used to communicate with Canvas.
        ///     This cannot be set at the same time as BackchannelCertificateValidator unless the value
        ///     can be downcast to a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        ///     The request path within the application's base path where the user-agent will be returned.
        ///     The middleware will process this request when it arrives.
        ///     Default value is "/signin-Canvas".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        /// Get or sets the text that the user can display on a sign in user interface.
        /// </summary>
        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        /// <summary>
        /// Gets or sets the Canvas supplied Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Canvas supplied Client Secret
        /// </summary>
        public string ClientKey { get; set; }

        /// <summary>
        /// Gets the sets of OAuth endpoints used to authenticate against Canvas.  Overriding these endpoints allows you to use Canvas Enterprise for
        /// authentication.
        /// </summary>
        public CanvasAuthenticationEndpoints Endpoints { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICanvasforceAuthenticationProvider" /> used in the authentication events
        /// </summary>
        public ICanvasAuthenticationProvider Provider { get; set; }

        /// <summary>
        /// A list of permissions to request.
        /// </summary>
        public IList<string> Scope { get; private set; }

        /// <summary>
        ///     Gets or sets the name of another authentication middleware which will be responsible for actually issuing a user
        ///     <see cref="System.Security.Claims.ClaimsIdentity" />.
        /// </summary>
        public string SignInAsAuthenticationType { get; set; }

        /// <summary>
        ///     Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
        public TimeSpan BackchannelTimeout { get; internal set; }

        /// <summary>
        ///     Initializes a new <see cref="CanvasAuthenticationOptions" />
        /// </summary>
        public CanvasAuthenticationOptions()
            : base("Canvas")
        {
            Caption = Constants.DefaultAuthenticationType;
            CallbackPath = new PathString("/signin-canvas");
            AuthenticationMode = AuthenticationMode.Passive;
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            Endpoints = new CanvasAuthenticationEndpoints
            {
                AuthorizationEndpoint = AuthorizationEndPoint,
                TokenEndpoint = TokenEndpoint
            };
        }
    }
}