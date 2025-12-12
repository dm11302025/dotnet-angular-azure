using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComm.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            // Placeholder logic to retrieve an order by its ID
            var order = new
            {
                OrderId = orderId,
                ProductName = "Sample Product",
                Quantity = 2,
                Price = 29.99
            };
            return Ok(order);
        }
    }
}
