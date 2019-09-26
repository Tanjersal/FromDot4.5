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
            Product[] products =
            {
                new Product { Name = "Kayak", Price = 275M},
                new Product { Name = "Toyota corrola", Price = 999M},
                new Product {Name = "Samsung TV", Price = 143M}
            };


            return View(products);
        }
    }
}