using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related { get; set; } // chaining null operator

        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 274M
            };

            Product lifejacket = new Product
            {
                Name = "LifeJacket",
                Price = 43.98M
            };

            kayak.Related = lifejacket;

            return new Product[] { kayak, lifejacket, null }; 
        }

    }
}
