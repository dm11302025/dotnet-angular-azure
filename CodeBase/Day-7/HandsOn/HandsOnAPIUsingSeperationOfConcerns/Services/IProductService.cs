using HandsOnAPIUsingSeperationOfConcerns.DTOs;
using HandsOnAPIUsingSeperationOfConcerns.Models;

namespace HandsOnAPIUsingSeperationOfConcerns.Services
{
    public interface IProductService
    {
        //5. Service Interface — Defines Business Logic Contract
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        void CreateProduct(ProductDto dto);
        void RemoveProduct(int id);
    }
}
