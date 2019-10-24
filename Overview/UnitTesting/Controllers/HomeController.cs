using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitTesting.Models;

namespace UnitTesting.Controllers
{
    public class HomeController : Controller
    {
        public IRepository repository = Repository.GetRepository;

        public ViewResult Index()
        {
            //return View(repository.Products.Where(x => x.Price > 200));
            return View(repository.Products);
        }

        [HttpGet]
        public ViewResult AddProduct()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}