using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.DTOs;
using OrderService.Messaging;
using OrderService.Models;
using OrderService.Repository;
using Shared.Contracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderRepository _repository;
        private readonly InventoryQueuePublisher _publisher;

        public OrdersController(
            OrderRepository repository,
            InventoryQueuePublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            // 1. Save order
            var order = new Order
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            var savedOrder = _repository.Add(order);

            // 2. Send command to InventoryService
            var command = new ReserveInventoryCommand
            {
                OrderId = savedOrder.Id,
                ProductId = savedOrder.ProductId,
                Quantity = savedOrder.Quantity
            };

            await _publisher.SendAsync(command);

            return Ok(new
            {
                Message = "Order created successfully",
                OrderId = savedOrder.Id
            });
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_repository.GetAll());
        }
    }
}
