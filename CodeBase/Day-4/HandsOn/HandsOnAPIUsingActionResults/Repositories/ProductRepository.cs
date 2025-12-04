using HandsOnAPIUsingActionResults.Models;
using System.Xml.Linq;

namespace HandsOnAPIUsingActionResults.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public ProductRepository()
        {
            // Seed sample data
            _products.Add(new Product { Id = 1, Name = "Laptop", Description = "Dell i5", Price = 55000, Stock = 10 });
            _products.Add(new Product { Id = 2, Name = "Mobile", Description = "Samsung A52", Price = 22000, Stock = 20 });
        }

        public IEnumerable<Product> GetAll() => _products;

        public Product? Get(int id) => _products.FirstOrDefault(x => x.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(x => x.Id) + 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = Get(product.Id);
            if (existing == null) return;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
        }

        public void Delete(int id)
        {
            var product = Get(id);
            if (product != null)
                _products.Remove(product);
        }
    }

}
