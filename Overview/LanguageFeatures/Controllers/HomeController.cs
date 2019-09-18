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
            object[] data = new object[]
            {
                275M,
                29.31M,
                12.09M, 
                "apple",
                100, 
                20
            };

            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                switch(data[i])
                {
                    case decimal decimalValue:
                        total = total + decimalValue;
                        break;
                    case int intValue when intValue > 50:
                        total = total + intValue;
                        break;
                }
            }

            return View("Index", new string[] { $"Total: {total:C2}" });
        }
    }
}