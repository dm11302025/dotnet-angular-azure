using HandsOnAPIWithGenericRepositoryPattern.Models;
using HandsOnAPIWithGenericRepositoryPattern.Repositories;

namespace HandsOnAPIWithGenericRepositoryPattern.CustomRepositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer? FindByEmail(string email);
    }
}
