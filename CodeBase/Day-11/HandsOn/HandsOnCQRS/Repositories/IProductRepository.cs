using HandsOnCQRS.Models;

namespace HandsOnCQRS.Repositories
{
    public interface IProductRepository
    {
        //async functions
         Task  AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> FindByIdAsync(int id);
        Task UpdateAsync(Product product);
        Task DeleteByIdAsync(int id);


    }
}
