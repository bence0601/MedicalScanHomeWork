using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Tests
{
    [TestFixture]
    public class PageControllerTests
    {
        private PageController _controller;
        private Mock<IPageService> _pageServiceMock;

        [SetUp]
        public void Setup()
        {
            _pageServiceMock = new Mock<IPageService>();
            _controller = new PageController(_pageServiceMock.Object);
        }

        [Test]
        public async Task GetAllProducts_ReturnsOkObjectResult_WithListOfProducts()
        {
            // Arrange
            var products = new List<ProductModel> { new ProductModel { Id = 1, Name = "Product 1" } };
            _pageServiceMock.Setup(service => service.GetAllProducts()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(products, okResult.Value);
        }

        [Test]
        public async Task GetProductById_ReturnsOkObjectResult_WithProduct()
        {
            // Arrange
            var productId = 1;
            var product = new ProductModel { Id = productId, Name = "Product 1" };
            _pageServiceMock.Setup(service => service.GetProductById(productId)).ReturnsAsync(product);

            // Act
            var result = await _controller.GetProductById(productId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(product, okResult.Value);
        }

        [Test]
        public async Task CreateProduct_ReturnsOkObjectResult_WithListOfProducts()
        {
            // Arrange
            var model = new ProductModel { Id = 1, Name = "New Product" };
            var products = new List<ProductModel> { model };
            _pageServiceMock.Setup(service => service.CreateNewProduct(model)).ReturnsAsync(products);

            // Act
            var result = await _controller.CreateProduct(model);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(products, okResult.Value);
        }

        [Test]
        public async Task UpdateProduct_ReturnsOkObjectResult_WithUpdatedProduct()
        {
            // Arrange
            var productId = 1;
            var model = new ProductModel { Id = productId, Name = "Updated Product" };
            _pageServiceMock.Setup(service => service.UpdateProduct(productId, model)).ReturnsAsync(model);

            // Act
            var result = await _controller.UpdateProduct(productId, model);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(model, okResult.Value);
        }

        [Test]
        public async Task DeleteProduct_ReturnsOkObjectResult_WithListOfProducts()
        {
            // Arrange
            var productId = 1;
            var products = new List<ProductModel> { new ProductModel { Id = productId, Name = "Product 1" } };
            _pageServiceMock.Setup(service => service.DeleteProduct(productId)).ReturnsAsync(products);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(products, okResult.Value);
        }
    }
}
