using Microsoft.EntityFrameworkCore;
using EComm.IdentityService.Entities;
namespace EComm.IdentityService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
