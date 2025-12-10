using InMemoryApiDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace InMemoryApiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
