using CrudWithSQLiteDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudWithSQLiteDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
