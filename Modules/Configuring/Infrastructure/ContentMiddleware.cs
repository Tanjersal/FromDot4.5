using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuring.Infrastructure
{
    /// <summary>
    /// Content Middleware service
    /// </summary>
    public class ContentMiddleware
    {
        private RequestDelegate requestDelegate; // process HTTP request
        private UptimeService UptimeService;

        public ContentMiddleware(RequestDelegate request, UptimeService uptimeService)
        {
            requestDelegate = request;
            UptimeService = uptimeService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync($"Response middleware with uptime: " +
                    $"{UptimeService.Uptime} ms", encoding: Encoding.UTF8);
            }
            else
            {
                await requestDelegate.Invoke(httpContext);
            }
        }
    }
}
