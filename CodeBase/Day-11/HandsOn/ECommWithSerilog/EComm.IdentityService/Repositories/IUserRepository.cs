using EComm.IdentityService.Entities;

namespace EComm.IdentityService.Repositories
{
    public interface IUserRepository
    {
        Task Register(User user);
        Task<User> Validate(string email , string password);
    }
}
