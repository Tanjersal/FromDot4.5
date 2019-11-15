using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuring.Infrastructure
{
    /// <summary>
    /// Response editing middleware
    /// </summary>
    public class ErrorMiddleware
    {
        private RequestDelegate requestDelegate;

        public ErrorMiddleware(RequestDelegate request)
        {
            requestDelegate = request;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await requestDelegate.Invoke(httpContext);

            if(httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else if(httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("No content middleware response", Encoding.UTF8);
            } 
        }

    }
}
