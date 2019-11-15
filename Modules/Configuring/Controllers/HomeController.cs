using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuring.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Configuring.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptimeService;

        public HomeController(UptimeService uptime)
        {
            uptimeService = uptime;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public ViewResult Index(bool throwException = false)
        {
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