using EComm.ProductService.Entities;
using Microsoft.EntityFrameworkCore;
namespace EComm.ProductService.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
            });
            //seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Pen",Price = 9 },
                new Product { Id = 2, Name = "Book", Price = 19 }
            );
        }
    }
}
