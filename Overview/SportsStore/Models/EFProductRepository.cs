using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        // application context 
        private ApplicationDbContext dbContext;

        public EFProductRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        /// <summary>
        /// Retrieves all products
        /// </summary>
        public IQueryable<Product> Products => dbContext.Products;


        /// <summary>
        /// Save product
        /// </summary>
        /// <param name="product"></param>
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                dbContext.Add(product);
            }
            else
            {
                Product dbEntry = dbContext.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                    dbEntry.Price = product.Price;
                }
            }

            dbContext.SaveChanges();
        }
    }
}
