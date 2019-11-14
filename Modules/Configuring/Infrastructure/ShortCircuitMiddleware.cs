using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuring.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate requestDelegate;

        public ShortCircuitMiddleware(RequestDelegate next)
        {
            requestDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["User-Agent"]
                .Any(x => x.ToLower().Contains("edge")))
            {
                httpContext.Response.StatusCode = 403; //terminate request
            }
            else
                await requestDelegate.Invoke(httpContext); //call next middleware
        }
    }
}
