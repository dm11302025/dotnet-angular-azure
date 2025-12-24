using CosmosCrudApi.Models;

namespace CosmosCrudApi.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id, string category);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(string id, string category);
    }

}
