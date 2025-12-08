using HandsOnAPIUsingSeperationOfConcerns.Models;

namespace HandsOnAPIUsingSeperationOfConcerns.Repositories
{
    //3. Repository Interface — Defines Data Access Contract
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        void Add(Product product);
        void Delete(int id);
    }
}
