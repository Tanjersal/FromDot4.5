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

        public ViewResult Index()
        {
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the index action",
                ["Uptime"] = $"{uptimeService.Uptime}ms"
            });
        }
    }
}