using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Configuring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel() // server kestrel
                .UseContentRoot(Directory.GetCurrentDirectory()) // current directory
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); //json config file

                    config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true); //adding env specific config file

                    config.AddEnvironmentVariables(); //env variables

                    if(args != null)
                    {
                        config.AddCommandLine(args); // add config to read command line
                    }
                })
                .ConfigureLogging((hostingContext, config) => //adding logging
                {
                    config.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    config.AddConsole();
                    config.AddDebug();
                })
                .UseIISIntegration() // IIS and IIS express
                .UseDefaultServiceProvider((context, options) => //register services
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .UseStartup<Startup>() // Startup and build
                .Build();
        }
    }
}
