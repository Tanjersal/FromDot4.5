using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTesting.Models
{
    public class Repository: IRepository
    {
        private static Repository simpleRepository = new Repository();
        public static Repository GetRepository => simpleRepository;

        public Dictionary<string, Product> productsDict = new Dictionary<string, Product>();
       
        public Repository()
        {
            var initialProducts = new[]
            {
                new Product {Name = "Kayak", Price = 210M},
                new Product {Name = "Soccer ball", Price = 10M},
                new Product {Name = "Christiano Ronaldo", Price = 900M},
                new Product {Name = "Toyota Corolla", Price = 500M},
                new Product { Name = "iPhone 11", Price = 122M}
            };

            foreach(Product p in initialProducts)
            {
                AddProduct(p);
            }
        }

        /// <summary>
        /// Add Product to dictionnary
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            productsDict.Add(product.Name, product);
        }

        /// <summary>
        /// return list of products in dict
        /// </summary>
        public IEnumerable<Product> Products => productsDict.Values;
    }
}
