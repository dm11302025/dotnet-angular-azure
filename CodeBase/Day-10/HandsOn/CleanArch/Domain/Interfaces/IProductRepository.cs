namespace CleanArch.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CleanArch.Domain.Entities;


    // Repository interface lives in Domain — depends only on Domain primitives
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
