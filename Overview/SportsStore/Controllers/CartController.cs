﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Infrastructure;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository productRepository;

        public CartController(IProductRepository repository)
        {
            productRepository = repository;
        }

        /// <summary>
        /// Index Controller
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }


        /// <summary>
        /// Add To Cart controller
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToActionResult AddToCart(int productID, string returnUrl)
        {
            Product product = productRepository.Products
                .Where(x => x.ProductID == productID)
                .FirstOrDefault();

            if(product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(1, product);
                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }


        /// <summary>
        /// Remove product from cart
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public RedirectToActionResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = productRepository.Products.Where(x => x.ProductID == productID).FirstOrDefault();

            if(product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLineItem(product);
                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }


        /// <summary>
        /// Get user cart in session
        /// </summary>
        /// <returns></returns>
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }


        /// <summary>
        /// Set user cart in session
        /// </summary>
        /// <param name="cart"></param>
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

    }
}