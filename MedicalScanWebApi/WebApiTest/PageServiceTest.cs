using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace PageServiceTests
{
    [TestFixture]
    public class PageServiceTests
    {
        private PageService _pageService;
        private string _filePath = "ProductData.json";

        [SetUp]
        public void Setup()
        {
            _pageService = new PageService();
        }

        [Test]
        public async Task CreateNewProduct_ValidProduct_ReturnsListOfProducts()
        {
            // Arrange
            var model = new ProductModel { Id = 1, Name = "Test Product", Price = 10.99m };

            // Act
            var result = await _pageService.CreateNewProduct(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any(p => p.Id == model.Id));
        }

        [Test]
        public async Task DeleteProduct_ExistingProductId_RemovesProductFromList()
        {
            // Arrange
            var existingProductId = 1;

            // Act
            var products = await _pageService.DeleteProduct(existingProductId);

            // Assert
            Assert.IsFalse(products.Any(p => p.Id == existingProductId));
        }

        [Test]
        public async Task GetAllProducts_NoProducts_ReturnsEmptyList()
        {
            // Arrange
            File.Delete(_filePath);

            // Act
            var products = await _pageService.GetAllProducts();

            // Assert
            Assert.IsEmpty(products);
        }

        [Test]
        public async Task GetProductById_ExistingProductId_ReturnsProduct()
        {
            // Arrange
            var existingProductId = 1;
            var expectedProduct = new ProductModel { Id = existingProductId, Name = "Test Product", Price = 10.99m };

            // Act
            var product = await _pageService.GetProductById(existingProductId);

            // Assert
            Assert.IsNotNull(product);
            Assert.AreEqual(existingProductId, product.Id);
        }



        [Test]
        public async Task UpdateProduct_ExistingProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            var existingProductId = 1;
            var updatedModel = new ProductModel { Id = existingProductId, Name = "Updated Product", Price = 15.99m };

            // Act
            var updatedProduct = await _pageService.UpdateProduct(existingProductId, updatedModel);

            // Assert
            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(updatedModel.Name, updatedProduct.Name);
            Assert.AreEqual(updatedModel.Price, updatedProduct.Price);
        }
    }
}
