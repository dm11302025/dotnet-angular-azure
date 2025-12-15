using HandsOnCQRS.DTOs;
using HandsOnCQRS.Models;
using HandsOnCQRS.Queries;
using HandsOnCQRS.Repositories;

namespace HandsOnCQRS.QueryHandlers
{
    public class GetAllProductsQueryHandler
    {
        private readonly IProductRepository _repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDto>> HandleAsync(GetAllProductsQuery query)
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }
    }

}
