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
            List<string> results = new List<string>();

            foreach (Product product in Product.GetProducts())
            {
                string name = product?.Name ?? "<No Name>"; //combining conditional and coalescent
                decimal? price = product?.Price ?? 0;

                string relatedName = product?.Related?.Name ?? "<None>"; // detecting null chain

                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}, Category: {3}", name, price, relatedName, product?.Category));
                results.Add($"Name: {name}, Price: {price}, Category: {product?.Category}, Related: {relatedName}"); // string interpolation
            }
            return View(results);
        }
    }
}