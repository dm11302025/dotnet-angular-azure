using Application.DTOs;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Queries;

public class GetProductsQueryHandler
{
    private readonly IProductRepository _repository;

    public GetProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductDto>> HandleAsync(GetProductsQuery query)
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
