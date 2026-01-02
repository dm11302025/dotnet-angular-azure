using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Infrastructure;
using Shared.Contracts.Events;
using OrderService.DTO;
namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _db;
        private readonly ServiceBusPublisher _publisher;

        public OrdersController(OrderDbContext db, ServiceBusPublisher publisher)
        {
            _db = db;
            _publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            var order = new Order
            {
                Status = "Pending"
            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            await _publisher.PublishAsync(new OrderCreatedEvent
            {
                OrderId = order.Id,
                Amount = request.Amount,
                CorrelationId = Guid.NewGuid()
            });

            return Ok(order);
        }

    }

}
