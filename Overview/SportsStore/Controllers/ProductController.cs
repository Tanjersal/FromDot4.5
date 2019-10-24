using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository; // repository for DI

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository">repository</param>
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        /// <summary>
        /// List controller
        /// </summary>
        /// <returns></returns>
        public ViewResult List() => View(repository.Products);
    }
}