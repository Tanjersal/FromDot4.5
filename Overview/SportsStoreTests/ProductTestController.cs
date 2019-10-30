using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text;
using Xunit;
using Moq;
using SportsStore.Models;
using System.Linq;
using SportsStore.Controllers;
using SportsStore.Models.ViewModels;
using SportsStore.Components;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Product> result = controller.List(null, 2).ViewData.Model as IEnumerable<Product>;

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
            ProductListViewModel productListViewModel = controller.List(null, 2).Model as ProductListViewModel;

            //assert
            PageInfo pageInfo = productListViewModel.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }


        /// <summary>
        /// Filter by category
        /// </summary>
        [Fact]
        public void Can_FilterByCategory()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns((new Product[]
            {
                new Product { Name = "P1", Category = "Cat1"},
                new Product { Name = "P2", Category = "Cat2"},
                new Product { Name = "P3", Category = "Cat3"},
                new Product { Name = "P4", Category = "Cat3"},
                new Product { Name = "P5", Category = "Cat3"}

            }).AsQueryable());

            //act
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            Product[] products = (controller.List("Cat3", 1).ViewData.Model as ProductListViewModel)
                .Products.ToArray();

            //Assert
            Assert.Equal(3, products.Length);
            Assert.True(products[0].Name == "P3" && products[0].Category == "Cat3");
            Assert.True(products[1].Name == "P4" && products[0].Category == "Cat3");
            Assert.True(products[2].Name == "P5" && products[0].Category == "Cat3");
        }


        /// <summary>
        /// Indicate the selected category
        /// </summary>
        [Fact]
        public void Indicates_Selected_Category()
        {
            // arrange
            string selectedCategory = "Apples";

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns((new Product[]
            {
                new Product { ProductID = 1, Category = "Apples"},
                new Product { ProductID = 3, Category = "Oranges"}

            }).AsQueryable());

            //act
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            //get route data through viewComponent
            target.ViewComponentContext = new ViewComponentContext()
            {
                ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };

            target.RouteData.Values["Category"] = selectedCategory;

            string result = (target.Invoke() as ViewViewComponentResult).ViewData["selectedCategory"].ToString();

            //assert
            Assert.Equal(selectedCategory, result);
        }


        /// <summary>
        /// Can generate right products and category count
        /// </summary>
        [Fact]
        public void Generate_Category_Specific_Count()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns((new Product[] 
            {
                new Product { ProductID = 1, Category = "Apples"},
                new Product { ProductID = 2, Category = "Oranges"},
                new Product { ProductID = 3, Category = "Apples"},
                new Product { ProductID = 4, Category = "Apples"},
                new Product { ProductID = 5, Category = "Oranges"}

            }).AsQueryable());

            //act
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            Func<ViewResult, ProductListViewModel> GetModel = result => result?.ViewData?.Model as ProductListViewModel;

            ProductListViewModel returnedViewModel = GetModel(controller.List("Apples", 1));

            //Assert
            Assert.Equal(3, returnedViewModel.Products.Count());
        }
    }
}
