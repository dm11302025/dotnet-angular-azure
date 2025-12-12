using EComm.ProductService.Repositories;
using EComm.ProductService.Entities;

namespace EComm.ProductService.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task CreateProduct(Product product)
        {
            await _productRepository.CreateProduct(product);
        }
        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetProductById(productId);
        }
        public async Task UpdateProduct(int id, Product product)
        {
            await _productRepository.UpdateProduct(id, product);
        }
    }
}
