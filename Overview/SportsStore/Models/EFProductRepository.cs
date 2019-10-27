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
    }
}
