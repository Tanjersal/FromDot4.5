using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext dbContext;

        public EFOrderRepository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        /// <summary>
        /// Get orders - all lines and product
        /// </summary>
        public IQueryable<Order> Orders => dbContext.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);

        /// <summary>
        /// Saving order
        /// </summary>
        /// <param name="order">new order</param>
        public void SaveOrders(Order order)
        {
            dbContext.AttachRange(order.Lines.Select(l => l.Product));

            if(order.OrderID == 0)
            {
                dbContext.Orders.Add(order);
            }

            dbContext.SaveChanges();
        }
    }
}
