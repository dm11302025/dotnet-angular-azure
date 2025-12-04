using HandsOnAPIWithGenericRepositoryPattern.Models;
using HandsOnAPIWithGenericRepositoryPattern.Repositories;

namespace HandsOnAPIWithGenericRepositoryPattern.CustomRepositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly List<Product> _data = new List<Product>();
       
        public IEnumerable<Product> GetProductsWithLowStock(int threshold)
        {
            return _data.Where(p => p.Stock < threshold);
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal min, decimal max)
        {
            return _data.Where(p => p.Price >= min && p.Price <= max);
        }

        public IEnumerable<Product> SearchByName(string keyword)
        {
            return _data.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));
        }
    }
}
