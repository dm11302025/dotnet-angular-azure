using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Shared.Contracts;
using Shared.Events;
namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly ServiceBusSender _sender;

        public OrderController(ServiceBusClient client, IConfiguration config)
        {
            _sender = client.CreateSender(config["ServiceBus:OrderTopic"]);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var orderId = Random.Shared.Next(1000, 9999);

            // Save order as Pending (DB omitted)

            var evt = new OrderCreatedEvent(
                orderId, request.ProductId, request.Quantity, request.Amount);

            await _sender.SendMessageAsync(
                new ServiceBusMessage(JsonSerializer.Serialize(evt)));

            return Ok(new { orderId });
        }
    }

}
