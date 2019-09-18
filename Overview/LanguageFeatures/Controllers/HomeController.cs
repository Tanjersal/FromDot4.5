using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;


namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.Products = Product.GetProducts();

            decimal totalCart = cart.TotalPrices(); // extension method

            return View("Index", new string[] { $"{totalCart:C2}" });
        }
    }
}