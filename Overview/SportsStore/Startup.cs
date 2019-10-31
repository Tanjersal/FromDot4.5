using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
        //reading config file
        private IConfiguration configuration;

        //DI
        public Startup(IConfiguration config)
        {
            configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration["Data:SportsStoreProducts:ConnectionString"]);
            });

            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                // /Category/Page2
                routes.MapRoute(
                    name: null,
                    template: "{category}/{productPage:int}",
                    defaults: new { controller = "Product", action = "List"}
                );
                // /Page2
                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1}
                );

                // /Soccer
                routes.MapRoute(
                    name: null,
                    template: "{Category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1}
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1}
                );

                //routes.MapRoute(
                //    name: "pagination",
                //    template: "Products/Page{productPage}",
                //    defaults: new { Controller = "Product", action = "List" }
                //);

                routes.MapRoute(
                    name: "default", 
                    template: "{controller=Product}/{action=List}/{id?}"
                );
            });

            SeedData.EnsurePopulated(app); //populate db
        }
    }
}
