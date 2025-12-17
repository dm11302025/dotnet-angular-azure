using HandsOnCQRS.DTOs;
using HandsOnCQRS.Queries;
using HandsOnCQRS.Repositories;

namespace HandsOnCQRS.QueryHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto?> HandleAsync(GetProductByIdQuery query)
        {
            var product = await _repository.FindByIdAsync(query.Id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
