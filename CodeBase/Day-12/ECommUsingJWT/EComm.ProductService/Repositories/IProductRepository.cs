using EComm.ProductService.Entities;
namespace EComm.ProductService.Repositories
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();
    }
}
