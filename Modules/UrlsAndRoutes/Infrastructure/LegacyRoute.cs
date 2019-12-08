using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Infrastructure
{
    public class LegacyRoute : IRouter
    {
        //urls
        private string[] _urls;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="targetUrls"></param>
        public LegacyRoute(params string[] targetUrls)
        {
            _urls = targetUrls;
        }


        /// <summary>
        /// Generate outgoing Urls
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        /// <summary>
        /// Handles incoming requests
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task RouteAsync(RouteContext context)
        {
            string RequestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');

            if(_urls.Contains(RequestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.Handler = async ctx =>
                {
                    HttpResponse response = ctx.Response;
                    byte[] bytes = Encoding.ASCII.GetBytes($"URL: { RequestedUrl }");
                    await response.Body.WriteAsync(bytes, 0, bytes.Length);
                }; 
            }

            return Task.CompletedTask;
        }
    }
}
