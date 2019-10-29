using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } //list of products
        public PageInfo PagingInfo { get; set; } //paging model
        public string CurrentCategory { get; set; } //selected category
    }
}
