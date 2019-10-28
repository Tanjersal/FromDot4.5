using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SportsStore.Models;
using System.Linq;
using SportsStore.Controllers;
using SportsStore.Models.ViewModels;

namespace SportsStoreTests
{
    public class ProductTestController
    {
        /// <summary>
        /// Testing pagination
        /// </summary>
        [Fact]
        public void Can_Paginate()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns((new Product[] {
                new Product { ProductID = 1, Name = "P1"}, 
                new Product { ProductID = 2, Name = "P2"},
                new Product { ProductID = 3, Name = "P3"},
                new Product { ProductID = 4, Name = "P4"}
            }).AsQueryable());

            
            //act
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;
            IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;

            //assert
            Product[] products = result.ToArray();
            Assert.True(products.Length == 1);
            Assert.Equal("P4", products[0].Name);
        }

        /// <summary>
        /// Testing viewModel and pagination
        /// </summary>
        /// 
        [Fact]
        public void Can_Send_Pagination_ViewModel()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns((new Product[]
            {
                new Product { Name = "P1", ProductID = 1},
                new Product { Name = "P2", ProductID = 2},
                new Product { Name = "P3", ProductID = 3},
                new Product { Name = "P4", ProductID = 4},
                new Product { Name = "P5", ProductID = 5}
            }).AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            //act
            ProductListViewModel productListViewModel = controller.List(2).Model as ProductListViewModel;

            //assert
            PageInfo pageInfo = productListViewModel.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
    }
}
