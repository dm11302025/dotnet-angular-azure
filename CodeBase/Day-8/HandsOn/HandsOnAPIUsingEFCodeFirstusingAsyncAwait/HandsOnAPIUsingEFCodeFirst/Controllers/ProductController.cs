using HandsOnAPIUsingEFCodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandsOnAPIUsingEFCodeFirst.DTOs;
namespace HandsOnAPIUsingEFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        //Dependency Injection of IProductService
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound("Invalid Id");
                }
                return Ok(product); //product return as JSON object with 200 status code
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productdto)
        {
           if(ModelState.IsValid)
            {
                try
                {
                    if (productdto == null)
                    {
                        return BadRequest("Product data is null");
                    }
                    await _productService.AddProductAsync(productdto);
                    return Ok(productdto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
           else
            {
                return BadRequest(ModelState);//400 bad request with validation errors
            }
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]int id,[FromBody] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    await _productService.UpdateProductAsync(id, productDto);
                    return Ok(productDto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);//400 bad request with validation errors
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok($"Product deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
