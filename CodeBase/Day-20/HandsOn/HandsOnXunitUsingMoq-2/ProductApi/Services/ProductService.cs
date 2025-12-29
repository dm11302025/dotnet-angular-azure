using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        // CREATE
        public async Task<Product> CreateAsync(Product product)
        {
            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            return await _repository.AddAsync(product);
        }

        // READ (Single)
        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            return product;
        }

        // READ (All)
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // UPDATE
        public async Task UpdateAsync(Product product)
        {
            var existing = await _repository.GetByIdAsync(product.Id);

            if (existing == null)
                throw new KeyNotFoundException("Product not found");

            await _repository.UpdateAsync(product);
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Product not found");

            await _repository.DeleteAsync(id);
        }
        public async Task<bool> IsAvailableAsync(int productId)
        {
            var product = await _repository.GetByIdAsync(productId);

            if (product == null)
                return false;
            return true;


        }
    }


}
