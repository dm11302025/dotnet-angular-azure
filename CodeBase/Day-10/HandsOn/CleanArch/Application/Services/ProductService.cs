using AutoMapper;
namespace CleanArch.Application.Services
{
    using CleanArch.Application.DTOs;
    using CleanArch.Application.Interfaces;
    using CleanArch.Domain.Entities;
    using CleanArch.Domain.Exceptions;
    using CleanArch.Domain.Interfaces;
    using System.Collections.Generic;


    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;


        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(p => _mapper.Map<ProductDto>(p));
        }


        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;
            return _mapper.Map<ProductDto>(product);
        }


        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new DomainException("Name must be provided");


            if (dto.Price <= 0)
                throw new DomainException("Price must be greater than zero");


            var entity = _mapper.Map<Product>(dto);
            await _repo.AddAsync(entity);
            return _mapper.Map<ProductDto>(entity);
        }


        public async Task UpdatePriceAsync(int id, decimal newPrice)
        {
            var product = await _repo.GetByIdAsync(id) ?? throw new DomainException("Product not found");
            product.UpdatePrice(newPrice); // domain behavior enforces invariants
            await _repo.UpdateAsync(product);
        }


        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
