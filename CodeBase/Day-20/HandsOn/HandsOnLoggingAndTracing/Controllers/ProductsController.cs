using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HandsOnLoggingAndTracing.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Fetching product with Id {ProductId}", id);

            if (id <= 0)
            {
                _logger.LogWarning("Invalid product id received: {ProductId}", id);
                return BadRequest();
            }

            try
            {
                // Simulate exception
                throw new Exception("Database connection failed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching product {ProductId}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost("order/{orderId}")]
        public IActionResult PlaceOrder(int orderId)
        {
            _logger.LogInformation(
      "Processing order {OrderId} with TraceId {TraceId}",
      orderId,
      Activity.Current?.TraceId.ToString());
            return Ok();
        }

    }
}
