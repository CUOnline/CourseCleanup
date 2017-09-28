using System;
using System.Globalization;
using System.Net.Http;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Owin;
using CourseCleanup.Web.Providers.Canvas.Provider;

namespace CourseCleanup.Web.Providers.Canvas
{
    public class CanvasAuthenticationMiddleware : AuthenticationMiddleware<CanvasAuthenticationOptions>
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public CanvasAuthenticationMiddleware(OwinMiddleware next, IAppBuilder app,
            CanvasAuthenticationOptions options)
            : base(next, options)
        {
            if (string.IsNullOrWhiteSpace(Options.ClientId))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Option must be provided.", "ClientId"));
            if (string.IsNullOrWhiteSpace(Options.ClientKey))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Option must be provided.", "ClientSecret"));

            _logger = app.CreateLogger<CanvasAuthenticationMiddleware>();

            if (Options.Provider == null)
                Options.Provider = new CanvasAuthenticationProvider();

            if (Options.StateDataFormat == null)
            {
                var dataProtector = app.CreateDataProtector(
                    typeof(CanvasAuthenticationMiddleware).FullName,
                    Options.AuthenticationType, "v1");
                Options.StateDataFormat = new PropertiesDataFormat(dataProtector);
            }

            if (string.IsNullOrEmpty(Options.SignInAsAuthenticationType))
                Options.SignInAsAuthenticationType = app.GetDefaultSignInAsAuthenticationType();

            _httpClient = new HttpClient(ResolveHttpMessageHandler(Options))
            {
                Timeout = Options.BackchannelTimeout,
                MaxResponseContentBufferSize = 1024 * 1024 * 10,
            };
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Microsoft Owin Canvas middleware");
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        /// <summary>
        ///     Provides the <see cref="T:Microsoft.Owin.Security.Infrastructure.AuthenticationHandler" /> object for processing
        ///     authentication-related requests.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:Microsoft.Owin.Security.Infrastructure.AuthenticationHandler" /> configured with the
        ///     <see cref="T:Owin.Security.Providers.Canvas.SalesforceAuthenticationOptions" /> supplied to the constructor.
        /// </returns>
        protected override AuthenticationHandler<CanvasAuthenticationOptions> CreateHandler()
        {
            return new CanvasAuthenticationHandler(_httpClient, _logger);
        }

        private static HttpMessageHandler ResolveHttpMessageHandler(CanvasAuthenticationOptions options)
        {
            var handler = options.BackchannelHttpHandler ?? new WebRequestHandler();

            // If they provided a validator, apply it or fail.
            if (options.BackchannelCertificateValidator == null) return handler;
            // Set the cert validate callback
            var webRequestHandler = handler as WebRequestHandler;
            if (webRequestHandler == null)
            {
                throw new InvalidOperationException("Validator Handler Missmatch");
            }
            webRequestHandler.ServerCertificateValidationCallback = options.BackchannelCertificateValidator.Validate;

            return handler;
        }
    }
}