using Microsoft.EntityFrameworkCore;
namespace HandsOnCQRS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<HandsOnCQRS.Models.Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data
            modelBuilder.Entity<HandsOnCQRS.Models.Product>().HasData(
                new HandsOnCQRS.Models.Product { Id = 1, Name = "Product 1", Price = 10.0m },
                new HandsOnCQRS.Models.Product { Id = 2, Name = "Product 2", Price = 20.0m }
            );
        }
    }
}
