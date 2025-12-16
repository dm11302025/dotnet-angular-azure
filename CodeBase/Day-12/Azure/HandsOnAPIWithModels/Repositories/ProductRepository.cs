using HandsOnAPIWithModels.Models;

namespace HandsOnAPIWithModels.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>()
    {
        new Product(){ Id = 1, Name = "Laptop", Price = 55000, Quantity = 10},
        new Product(){ Id = 2, Name = "Mouse", Price = 500, Quantity = 50}
    };

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return product;
        }

        public Product Update(Product product)
        {
            var existing = _products.FirstOrDefault(x => x.Id == product.Id);
            if (existing == null) return null;

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;

            return existing;
        }

        public bool Delete(int id)
        {
            var existing = _products.FirstOrDefault(x => x.Id == id);
            if (existing == null)
                return false;

            _products.Remove(existing);
            return true;
        }
    }

}
