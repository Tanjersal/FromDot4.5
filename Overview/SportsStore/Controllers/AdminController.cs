using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Index Controller
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(repository.Products);
        }

        /// <summary>
        /// Edit Controller
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public ViewResult Edit(int productID)
        {
            return View(repository.Products.FirstOrDefault(x => x.ProductID == productID));
        }


        /// <summary>
        /// Edit controller - POST
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
                return View(product);
        }
    }
}