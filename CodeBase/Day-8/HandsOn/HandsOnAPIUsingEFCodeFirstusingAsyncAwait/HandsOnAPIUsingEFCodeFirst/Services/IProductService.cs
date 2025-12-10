using HandsOnAPIUsingEFCodeFirst.DTOs;
using HandsOnAPIUsingEFCodeFirst.Entities;

namespace HandsOnAPIUsingEFCodeFirst.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task AddProductAsync(ProductDto product);
        Task UpdateProductAsync(int id,ProductDto product);
        Task DeleteProductAsync(int productId);
    }
}
