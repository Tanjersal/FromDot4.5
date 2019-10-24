using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting.Controllers;
using UnitTesting.Models;
using Xunit;

namespace UnitTesting.Tests
{
    public class HomeControllerTest
    {
        class ModelCompleteFakeRepository : IRepository
        {
            //public IEnumerable<Product> Products => new Product[]
            //{
            //    new Product { Name = "P1", Price = 275M},
            //    new Product { Name = "P2", Price = 48.95M},
            //    new Product { Name = "P3", Price = 19.50M},
            //    new Product { Name = "P3", Price = 34.95M}
            //};

            public IEnumerable<Product> Products { get; set; } 


            public void AddProduct(Product p)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void IndexActionModelIsComplete()
        {
            //arrange
            var controller = new HomeController();
            controller.repository = new ModelCompleteFakeRepository();


            //act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //assert
            Assert.Equal(Repository.GetRepository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }


        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 8.95, 19.50, 24.95)]
        public void IndexActionModelIsCompleteParameterize(decimal price1, decimal price2, decimal price3, decimal price4)
        {
            //arrange
            var controller = new HomeController();
            controller.repository = new ModelCompleteFakeRepository()
            {
                Products = new Product[]
                {
                    new Product { Name = "P1", Price = price1},
                    new Product { Name = "P2", Price = price2},
                    new Product { Name = "P3", Price = price3},
                    new Product { Name = "P4", Price = price4}
                }
            };

            //act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;


            //assert
            Assert.Equal(controller.repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
