using Application.Services;
using Domain.Entities;
using Application.Contracts;
using Application.DTOs;
using AutoMapper;
namespace Application.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CreateProductDto product)
        {
            var productEntity =_mapper.Map<Product>(product);
            await _productRepository.AddAsync(productEntity);
        }
        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
        public async Task<List<ProductDto>> GetAllAsync()
        {
            return  _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync());
        }
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetByIdAsync(id));
        }
        public async Task UpdateAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
