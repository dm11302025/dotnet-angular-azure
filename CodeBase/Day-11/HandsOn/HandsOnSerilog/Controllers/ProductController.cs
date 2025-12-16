using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace HandsOnSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            _logger.LogInformation("Fetching product with Id {ProductId}", id);

            if (id <= 0)
            {
                _logger.LogWarning("Invalid product id received: {ProductId}", id);
                return BadRequest();
            }

            try
            {
                var product = new { Id = id, Name = "Laptop", Price = 50000 };
                _logger.LogInformation("Product retrieved successfully {@Product}", product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching product {ProductId}", id);
                return StatusCode(500);
            }
        }
        [HttpPost]
        public IActionResult Error()
        {
            try
            {
                throw new Exception("Simulated exception for logging demonstration");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the Error endpoint");
                return StatusCode(500);
            }
        }
    }
}
