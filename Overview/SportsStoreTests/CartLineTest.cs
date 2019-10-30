using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SportsStore.Models;
using static SportsStore.Models.Cart;
using System.Linq;

namespace SportsStoreTests
{
    public class CartLineTest
    {
        [Fact]
        public void Can_AddItem_Cart()
        {
            //arrange
            Product testProduct = new Product()
            {
                Name = "Orange",
                Price = 901.87M,
                Category = "Testing"
            };

            //act
            Cart testCart = new Cart();
            testCart.AddItem(2, testProduct);

            CartLine[] cartLines = testCart.GetCartLines.ToArray();

            //assert
            Assert.Single(cartLines);
            
        }
    }
}
