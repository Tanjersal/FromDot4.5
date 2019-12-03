﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                // most specific routes first

                // custom segment id added (optional) - *for catchall
                //routes.MapRoute(
                //    name: "MyRoute",
                //    template: "{controller=Home}/{action=Index}/{id?}/{*catchall}"
                //);

                //routes constraint inline
                //routes.MapRoute(
                //    name: "MyRouteInline",
                //    template: "{controller=Home}/{action=Index}/{id:int?}"
                //);

                //routes constraint explicit
                //routes.MapRoute(
                //    name: "MyRoutesExplicit",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new { id = new IntRouteConstraint() }
                // );

                //combining constraints - inline alpha and min length 6
                //routes.MapRoute(
                //    name: "",
                //    template: "{controller=Home}/{action=Index}/{id:alpha:minLength(6)?}"
                //);

                //combining constraints - explicits alpha and min length 6
                //routes.MapRoute(
                //    name: "",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new { id = new CompositeRouteConstraint(
                //        new IRouteConstraint[]
                //        {
                //            new AlphaRouteConstraint(),
                //            new MinLengthRouteConstraint(6)
                //        }
                //    )}
                //);

                //applying the custom constraint - explicit
                routes.MapRoute(
                    name:"default",
                    template:"{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new { id = new WeekdayConstraint() }
                );
            });
        }
    }
}
