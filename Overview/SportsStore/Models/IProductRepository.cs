using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        //allows for better db queries (always convert to toList or 
       // toArray avoid multiple db calls) vs IEnumerable

        IQueryable<Product> Products { get; } 
    }
}
