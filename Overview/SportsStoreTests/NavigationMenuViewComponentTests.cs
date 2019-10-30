using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SportsStore.Models;
using System.Linq;
using SportsStore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace SportsStoreTests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //arrange 
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns((new Product[]
            {
                new Product { Name = "P1", Category = "Apples", ProductID = 1},
                new Product { Name = "P2", Category = "Apples", ProductID = 2},
                new Product { Name = "P3", Category = "Plums", ProductID = 3},
                new Product { Name = "P4", Category = "Orange", ProductID = 4},

            }).AsQueryable());

            //act
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            //assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Orange", "Plums" }, results));
        }
    }
}
