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
            ShoppingCart cart = new ShoppingCart()
            {
                Products = Product.GetProducts()
            };

            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 120M},
                new Product {Name = "Lifejacket", Price = 32.44M},
                new Product { Name = "Toyota Rav4", Price = 900.40M}
            };

            decimal totalProductArray = productArray.TotalPrice(); // extension applies to array list
            decimal totalCart = cart.TotalPrice();

            decimal yieldedTotalPrice = productArray.FilterByPrice(700).TotalPrice();

            return View("Index", new string[] { $"Total filter: {yieldedTotalPrice:C2}" });

            //return View("Index", new string[] { $"Cart Total: {totalCart:C2}", $"Array Total: {totalProductArray:C2}"});
        }
    }
}