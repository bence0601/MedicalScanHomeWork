using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet("Products")]
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
        {
            try
            {
                var products = await _pageService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving products.");
            }
        }

        [HttpGet("Product/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            try
            {
                var product = await _pageService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the product.");
            }
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<List<ProductModel>>> CreateProduct(ProductModel model)
        {
            try
            {
                var products = await _pageService.CreateNewProduct(model);
                return Ok(products);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the product.");
            }
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult<ProductModel>> UpdateProduct(int id, ProductModel model)
        {
            try
            {
                var updatedProduct = await _pageService.UpdateProduct(id, model);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the product.");
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<List<ProductModel>>> DeleteProduct(int id)
        {
            try
            {
                var products = await _pageService.DeleteProduct(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the product.");
            }
        }
    }
}
