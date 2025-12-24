using OrderService.Models;

namespace OrderService.Repository
{
    public class OrderRepository
    {
        private static readonly List<Order> _orders = new();
        private static int _id = 1;

        public Order Add(Order order)
        {
            order.Id = _id++;
            _orders.Add(order);
            return order;
        }

        public IEnumerable<Order> GetAll()
            => _orders;
    }
}
