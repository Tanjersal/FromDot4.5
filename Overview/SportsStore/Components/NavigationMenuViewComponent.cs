using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository productRepository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            productRepository = repository;
        }

        public IViewComponentResult Invoke()
        {
            // retrieve selected category
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(productRepository
                .Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
