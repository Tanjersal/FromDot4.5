using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> cartLines = new List<CartLine>(); //cartLines

        /// <summary>
        /// Add an item to the line
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="product"></param>
        public virtual void AddItem(int quantity, Product product)
        {
            CartLine line = cartLines.Where(x => x.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
                line.Quantity++;
            
        }

        /// <summary>
        /// Removes a line in the cart
        /// </summary>
        /// <param name="product"></param>
        public virtual void RemoveLineItem(Product product)
        {
            cartLines.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }


        /// <summary>
        /// Compute the total in the cart
        /// </summary>
        /// <returns></returns>
        public virtual decimal ComputeTotalCart()
        {
            return cartLines.Sum(x => x.Product.Price * x.Quantity);
        }

        /// <summary>
        /// Clears the cart
        /// </summary>
        public virtual void ClearLine()
        {
            cartLines.Clear();
        }

        /// <summary>
        /// Return the cartLine
        /// </summary>
        public IEnumerable<CartLine> GetCartLines => cartLines;


        /// <summary>
        /// cartLine model
        /// </summary>
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
