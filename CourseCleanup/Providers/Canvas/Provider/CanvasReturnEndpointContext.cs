using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseCleanup.Web.Providers.Canvas.Provider
{
    /// <summary>
    /// Provides context information to middleware providers.
    /// </summary>
    public class CanvasReturnEndpointContext : ReturnEndpointContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">OWIN environment</param>
        /// <param name="ticket">The authentication ticket</param>
        public CanvasReturnEndpointContext(IOwinContext context, AuthenticationTicket ticket)
            : base(context, ticket)
        {
        }
    }
}