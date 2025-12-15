using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLogging.Controllers
{
    [ApiController]
    [Route("api/products")]
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
            //LogDebug() used to show debug erros
            //
            _logger.LogDebug("Debug: Fetching product with id {ProductId}", id);
            _logger.LogInformation("GetProduct started. ProductId: {ProductId}", id);
            _logger.LogCritical("Critical: Critical Message");
            if (id <= 0)
            {
                _logger.LogWarning("Invalid ProductId received: {ProductId}", id);
                return BadRequest("Invalid product id");
            }

            try
            {
                // Simulate data access
                var product = new { Id = id, Name = "Laptop", Price = 50000 };

                _logger.LogInformation("Product fetched successfully. ProductId: {ProductId}", id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching product. ProductId: {ProductId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                throw new Exception("This is a test exception in the post method");

            }
            catch (Exception ex)
            {
                _logger.LogError("Log Error: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
