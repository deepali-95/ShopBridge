using Microsoft.AspNetCore.Mvc;
using Moq;
using ShopBridge.Microservices.Product.Api.Controllers;
using ShopBridge.Microservices.Product.Api.Infrastructure.Handlers.Interfaces;
using ShopBridge.Microservices.Product.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge.Microservices.Product.UnitTests
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task GetItemAsync_WithUnexistingItem_ReturnsNotFound()
        {
            // Arrange
            var productHandler = new Mock<IProductHandler>();
            productHandler.Setup(item => item.GetProductAsync(It.IsAny<int>()))
                .ReturnsAsync((ProductItem)null);

            var controller = new ProductController(productHandler.Object);

            // Act
            var result = await controller.Get(1000);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}
