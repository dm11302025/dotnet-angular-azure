using Microsoft.EntityFrameworkCore;
namespace HandsOnEFCoreUsingEntities.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
       // public DbSet<OrderItems> OrderItems { get; set; }
    }
   
}
