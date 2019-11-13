using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart; //user cart

        public OrderController(IOrderRepository orderRepository, Cart cartService)
        {
            repository = orderRepository;
            cart = cartService;
        }

        /// <summary>
        /// Get checkout
        /// </summary>
        /// <returns></returns>
        public ViewResult Checkout() => View(new Order());

        /// <summary>
        /// Post checkout
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.GetCartLines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.GetCartLines.ToArray();
                repository.SaveOrder(order);

                return RedirectToAction(nameof(Completed));
            }
            else
                return View(order);
        }


        public ViewResult Completed()
        {
            cart.ClearLine();
            return View();
        }


        /// <summary>
        /// List unshipped orders
        /// </summary>
        /// <returns></returns>
        public ViewResult List()
        {
            return View(repository.Orders.Where(x => !x.Shipped));
        }

        /// <summary>
        /// Set order to shipped status
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public IActionResult MarkShipped(int OrderID)
        {
            Order order = repository.Orders.FirstOrDefault(x => x.OrderID == OrderID);
            if(order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }

            return RedirectToAction(nameof(List));
        }
    }
}