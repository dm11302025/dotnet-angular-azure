using HandsOnAPIWithModelsAndDTOs.Models;

namespace HandsOnAPIWithModelsAndDTOs.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(x => x.Id == id);

        public Product Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing == null) return;

            existing.Name = product.Name;
            existing.Price = product.Price;
        }

        public void Delete(int id)
        {
            var p = GetById(id);
            if (p != null) _products.Remove(p);
        }
    }

}
