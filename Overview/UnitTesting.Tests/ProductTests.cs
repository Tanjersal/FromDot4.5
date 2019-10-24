using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting.Models;
using Xunit;

namespace UnitTesting.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //arrange
            var p = new Product { Name = "Testing", Price = 10M };

            //act 
            p.Name = "Changed Testing";

            //assert
            Assert.Equal("Changed Testing", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            var p = new Product { Name = "Fabien", Price = 59000M };

            p.Price = 9003041M;

            Assert.Equal(9003041, p.Price);

        }
    }
}
