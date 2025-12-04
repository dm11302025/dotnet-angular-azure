using HandsOnAPIWithGenericRepositoryPattern.Models;
using HandsOnAPIWithGenericRepositoryPattern.Repositories;

namespace HandsOnAPIWithGenericRepositoryPattern.CustomRepositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly List<Customer> _data = new List<Customer>();
        public Customer? FindByEmail(string email)
        {
            return _data.FirstOrDefault(c => c.Email == email);
        }
    }
}
