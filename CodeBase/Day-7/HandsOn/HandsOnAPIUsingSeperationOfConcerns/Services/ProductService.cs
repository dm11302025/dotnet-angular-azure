using HandsOnAPIUsingSeperationOfConcerns.DTOs;
using HandsOnAPIUsingSeperationOfConcerns.Models;
using HandsOnAPIUsingSeperationOfConcerns.Repositories;

namespace HandsOnAPIUsingSeperationOfConcerns.Services
{
    public class ProductService : IProductService
    {
        //6. Service Implementation — Contains Business Logic
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> GetAllProducts() => _repo.GetAll();

        public Product GetProduct(int id) => _repo.Get(id);

        public void CreateProduct(ProductDto dto)
        {
            if (dto.Price <= 0)
                throw new Exception("Price must be greater than zero.");

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            _repo.Add(product);
        }

        public void RemoveProduct(int id)
        {
            _repo.Delete(id);
        }
    }
}
