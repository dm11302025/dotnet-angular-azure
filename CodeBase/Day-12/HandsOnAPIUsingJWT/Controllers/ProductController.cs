using HandsOnAPIUsingJWT.Entities;
using HandsOnAPIUsingJWT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        //End Points
        [HttpGet("GetAllProducts")]
        [Authorize]//access to every authenticated user 
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("GetProductById/{id}")]
        [Authorize(Roles = "Admin,User")] //access to authenticated users with Admin or User role
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            await productRepository.AddProductAsync(product);
            return Ok(product);
        }
        [HttpPut("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            var existingProduct = await productRepository.GetProductByIdAsync(product.ProductId);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await productRepository.UpdateProductAsync(product);
            return NoContent();
        }
        [HttpDelete("DeleteProduct/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await productRepository.DeleteProductAsync(id);
            return NoContent();
        }

    }
}
