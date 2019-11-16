using Configuring.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuring
{
    public class Startup
    {

        // To read config file
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>(); //shared instance throughout the app
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // if setting is set in json
            if((Configuration.GetSection("ShortCircuitMiddleware")?.GetValue<bool>("EnableBrowserShortCircuit")).Value)
            {
                app.UseMiddleware<BrowserTypeMiddleware>();
                app.UseMiddleware<ShortCircuitMiddleware>();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseBrowserLink();
            }
            else
            {
                // exception handler for staging and prod env
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //setting up routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
