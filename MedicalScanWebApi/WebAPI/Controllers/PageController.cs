using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class PageController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private readonly IPageService _pageService;

            public ProductController(IPageService pageService)
            {
                _pageService = pageService;
            }

            [HttpGet("Products")]
            public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
            {
                var products = await _pageService.GetAllProducts();
                return Ok(products);
            }

            [HttpGet("Product/{id}")]
            public async Task<ActionResult<ProductModel>> GetProductById(int id)
            {
                var product = await _pageService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }

            [HttpPost("CreateProduct")]
            public async Task<ActionResult<List<ProductModel>>> CreateProduct(ProductModel model)
            {
                var products = await _pageService.CreateNewProduct(model);
                return Ok(products);
            }

            [HttpPut("UpdateProduct/{id}")]
            public async Task<ActionResult<ProductModel>> UpdateProduct(int id, ProductModel model)
            {
                var updatedProduct = await _pageService.UpdateProduct(id, model);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok(updatedProduct);
            }

            [HttpDelete("DeleteProduct/{id}")]
            public async Task<ActionResult<List<ProductModel>>> DeleteProduct(int id)
            {
                var products = await _pageService.DeleteProduct(id);
                return Ok(products);
            }
        }
    }
}
