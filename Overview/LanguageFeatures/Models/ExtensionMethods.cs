using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Calculate Total price on shopping cart
        /// </summary>
        /// <param name="shoppingCart">Shopping Cart</param>
        /// <returns></returns>
        public static decimal TotalPrices(this ShoppingCart shoppingCart)
        {
            decimal total = 0;
            foreach (Product product in shoppingCart.Products)
            {
                total += product?.Price ?? 0;
            }

            return total;
        }
    }
}
