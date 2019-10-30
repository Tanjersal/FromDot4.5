using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository; // repository for DI
        public int pageSize = 4;

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
        public ViewResult List(string category, int productPage = 1)
        {
            return View(new ProductListViewModel
            {
                Products = repository.Products
                .Where(x => x.Category == null || x.Category == category)
                .OrderBy(x => x.ProductID)
                .Skip((productPage - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                    repository.Products.Count() : 
                    repository.Products.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
        }
    }
}