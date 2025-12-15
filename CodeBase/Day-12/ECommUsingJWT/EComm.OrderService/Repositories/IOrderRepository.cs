using EComm.OrderService.Entities;
namespace EComm.OrderService.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        Task CancelOrder(Guid orderId);
        Task<List<Order>> GetOrdersByUserId(string userId);
    }
}
