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
        public string Category { get; set; } = "Watersports"; // auto implemented prop
        public bool InStock { get; } //read only prop

        // assigning value to read only through constructor
        public Product(bool stock = true)
        {
            InStock = stock;
        }

        public static Product[] GetProducts()
        {
            Product kayak = new Product(false)
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 274M
            };

            Product lifejacket = new Product(true)
            {
                Name = "LifeJacket",
                Price = 43.98M
            };

            kayak.Related = lifejacket;

            return new Product[] { kayak, lifejacket, null }; 
        }

    }
}
