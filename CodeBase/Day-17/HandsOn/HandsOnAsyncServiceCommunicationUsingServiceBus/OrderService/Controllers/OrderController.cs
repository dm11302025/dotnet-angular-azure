using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Messaging;
using Shared.Contracts;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderEventPublisher _publisher;
        public OrderController(OrderEventPublisher publisher)
        {
            _publisher = publisher;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            // Save Order to DB (omitted)

            await _publisher.PublishOrderCreatedAsync(new OrderCreatedEvent
            {
                OrderId = 101,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            });

            return Ok("Order created and event published");
        }

    }
}
