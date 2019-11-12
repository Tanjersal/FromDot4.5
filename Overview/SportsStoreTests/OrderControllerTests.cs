using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SportsStore.Models;
using SportsStore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SportsStoreTests
{
    public class OrderControllerTests
    {
        [Fact]
        public void Cannot_Checkout_Empty_Cart()
        {
            //arrange
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            //Empty cart
            Cart cart = new Cart();

            Order order = new Order();

            OrderController orderController = new OrderController(mock.Object, cart);

            //act
            ViewResult result = orderController.Checkout(order) as ViewResult;

            //assert
            mock.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }
    }
}
