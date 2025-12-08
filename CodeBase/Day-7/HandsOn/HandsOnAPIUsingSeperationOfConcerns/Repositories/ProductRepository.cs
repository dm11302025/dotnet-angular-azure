using HandsOnAPIUsingSeperationOfConcerns.Models;

namespace HandsOnAPIUsingSeperationOfConcerns.Repositories
{
    //4. Repository Implementation — Actual Data Access Logic
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public IEnumerable<Product> GetAll() => _products;

        public Product Get(int id) => _products.FirstOrDefault(x => x.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public void Delete(int id)
        {
            var product = Get(id);
            if (product != null)
                _products.Remove(product);
        }
    }
}
