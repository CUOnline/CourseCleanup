using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Canvas.Clients
{
    public class CustomDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["CanvasToken"]);
            if (InnerHandler == null)
            {
                InnerHandler = new HttpClientHandler();
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
