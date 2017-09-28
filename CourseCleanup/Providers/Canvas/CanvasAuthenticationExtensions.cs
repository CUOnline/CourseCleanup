using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseCleanup.Web.Providers.Canvas
{
    public static class CanvasAuthenticationExtensions
    {
        public static IAppBuilder UseCanvasAuthentication(this IAppBuilder app, CanvasAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            app.Use(typeof(CanvasAuthenticationMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseCanvasAuthentication(this IAppBuilder app, string id, string key)
        {
            return app.UseCanvasAuthentication(new CanvasAuthenticationOptions
            {
                ClientId = id,
                ClientKey = key
            });
        }
    }
}