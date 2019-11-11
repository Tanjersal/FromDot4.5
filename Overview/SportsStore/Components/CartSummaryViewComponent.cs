using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent: ViewComponent
    {
        private Cart cartService; // DI

        public CartSummaryViewComponent(Cart cart)
        {
            cartService = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(cartService);
        }
    }
}
