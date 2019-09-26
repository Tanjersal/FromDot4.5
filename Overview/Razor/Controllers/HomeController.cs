using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M,
                Description = "Boat for one person",
                ProductID = 1,
                Category = "WaterSports"
            };

            ViewBag.StockLevel = 5;

            return View(kayak);
        }
    }
}