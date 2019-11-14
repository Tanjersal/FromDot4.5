using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuring.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate RequestDelegate;

        public BrowserTypeMiddleware(RequestDelegate next)
        {
            RequestDelegate = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            //Dict Items can be used to share data in current context
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"]
                .Any(x => x.ToLower().Contains("edge"));

            await RequestDelegate.Invoke(httpContext);
        }

    }
}
