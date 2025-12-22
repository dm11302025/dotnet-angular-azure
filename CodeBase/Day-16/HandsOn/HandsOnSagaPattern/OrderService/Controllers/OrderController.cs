using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Entities;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private static readonly List<Order> _orders = new();

        [HttpPost]
        public IActionResult CreateOrder()
        {
            var order = new Order { Id = _orders.Count + 1, Status = "Pending" };
            _orders.Add(order);
            return Ok(new { order.Id });
        }

        [HttpPost("{id}/cancel")]
        public IActionResult CancelOrder(int id)
        {
            var order = _orders.First(o => o.Id == id);
            order.Status = "Cancelled";
            return Ok();
        }

        [HttpPost("{id}/complete")]
        public IActionResult CompleteOrder(int id)
        {
            var order = _orders.First(o => o.Id == id);
            order.Status = "Completed";
            return Ok();
        }
    }

}
