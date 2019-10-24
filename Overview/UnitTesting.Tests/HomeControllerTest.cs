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
            public IEnumerable<Product> Products => new Product[]
            {
                new Product { Name = "P1", Price = 275M},
                new Product { Name = "P2", Price = 48.95M},
                new Product { Name = "P3", Price = 19.50M},
                new Product { Name = "P3", Price = 34.95M}
            };

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
    }
}
