using OrderService.Repositories;

namespace OrderService.Services
{
    public class OrderService
    {
        private readonly IProductRepository _repository;

        public OrderService(IProductRepository repository)
        {
            _repository = repository;
        }

        public bool CanPlaceOrder(int productId)
        {
            var stock = _repository.GetStock(productId);
            return stock > 0;
        }
    }
}
