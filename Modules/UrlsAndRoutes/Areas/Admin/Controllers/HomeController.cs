using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Areas.Admin.Models;

namespace UrlsAndRoutes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private Person[] data = new Person[]
        {
            new Person { Name = "Fabien", City = "Sioux Falls" },
            new Person { Name = "Arnaud", City = "Paris" },
            new Person { Name = "Nadia", City = "Ouaga"}
        };

        /// <summary>
        /// Index controller
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View(data);
        }
    }
}