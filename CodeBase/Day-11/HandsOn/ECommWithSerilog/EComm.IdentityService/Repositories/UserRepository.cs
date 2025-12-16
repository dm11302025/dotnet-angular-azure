using EComm.IdentityService.Data;
using EComm.IdentityService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EComm.IdentityService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        //Intialize the context through constructor injection(DI)
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        //Method to register a new user
        public async Task Register(User user)
        {
            await _context.Users.AddAsync(user);
             _context.SaveChanges();
        }

        public async Task<User> Validate(string email, string password)
        {
            //Check if the user with given email and password exists in the database
            var user = await _context.Users.SingleOrDefaultAsync
                (u=>u.Email==email && u.Password==password);
            return user;

        }
    }
}
