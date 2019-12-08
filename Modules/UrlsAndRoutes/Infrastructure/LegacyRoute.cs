using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
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

        //MvcRoute
        private IRouter MvcRoute;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="targetUrls"></param>
        public LegacyRoute(IServiceProvider serviceProvider, params string[] targetUrls)
        {
            _urls = targetUrls;
            MvcRoute = serviceProvider.GetRequiredService<MvcRouteHandler>();
        }


        /// <summary>
        /// Generate outgoing Urls
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            //outgoing url
            if (context.Values.ContainsKey("legacyUrl"))
            {
                string url = context.Values["legacyUrl"] as string;
                if(_urls.Contains(url))
                {
                    return new VirtualPathData(this, url);
                }
            }

            return null;
        }

        /// <summary>
        /// Handles incoming requests
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task RouteAsync(RouteContext context)
        {
            string RequestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');

            if(_urls.Contains(RequestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.RouteData.Values["controller"] = "Legacy"; //setting controller
                context.RouteData.Values["action"] = "GetLegacyUrl"; //setting action
                context.RouteData.Values["legacyUrl"] = RequestedUrl; //setting segment

                await MvcRoute.RouteAsync(context); //handler directs request to respective controller
            }
        }
    }
}
