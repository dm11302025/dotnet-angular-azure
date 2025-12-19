using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using Microsoft.AspNetCore.Http;
namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Invalid order data.");
            }
            // Simulate order processing logic here (e.g., save to database)
            await _httpClient.PostAsync(
            $"http://localhost:7167/api/SendEmail?to={orderDto.Email}&subject=Order Confirmation&body=Thank you for your order, {orderDto.Name}!",
            null);
            return Ok("Order placed successfully.");
        }
    }
}
