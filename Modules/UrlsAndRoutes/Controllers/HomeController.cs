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
    }
}