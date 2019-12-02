using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Index controller - prints request info
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        /// <summary>
        /// Custom variables segment
        /// </summary>
        /// <returns></returns>
        public ViewResult CustomVariables()
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariables)
            };

            r.data["Id"] = RouteData.Values["Id"]; //routeData enables to access routing info

            return View("Result", r);
        }
    }
}