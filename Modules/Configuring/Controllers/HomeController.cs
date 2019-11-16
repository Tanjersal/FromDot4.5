using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuring.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Configuring.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptimeService;
        private ILogger<HomeController> Logger;


        public HomeController(UptimeService uptime, ILogger<HomeController> logger)
        {
            uptimeService = uptime;
            Logger = logger;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public ViewResult Index(bool throwException = false)
        {
            Logger.LogDebug($"Handled {Request.Path} at uptime {uptimeService.Uptime} ms.");

            if(throwException)
            {
                throw new NullReferenceException();
            }

            return View(new Dictionary<string, string>
            {
                ["Message"] = "Index action",
                ["Uptime"] = $"{uptimeService.Uptime} ms"
            });
        }


        /// <summary>
        /// Error
        /// </summary>
        /// <returns></returns>
        public ViewResult Error()
        {
            return View(nameof(Index), new Dictionary<string, string>
            {
                ["Message"] = "This is the error action"
            });
        }
    }
}