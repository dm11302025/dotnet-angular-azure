using HandsOnAPIWithGenericRepositoryPattern.Models;
using HandsOnAPIWithGenericRepositoryPattern.Repositories;

namespace HandsOnAPIWithGenericRepositoryPattern.CustomRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProductsWithLowStock(int threshold);
        IEnumerable<Product> GetProductsByPriceRange(decimal min, decimal max);
        IEnumerable<Product> SearchByName(string keyword);
    }
}
