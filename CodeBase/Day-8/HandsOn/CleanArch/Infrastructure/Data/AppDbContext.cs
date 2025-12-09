namespace CleanArch.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using CleanArch.Domain.Entities;


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(200).IsRequired();
                b.Property(x => x.Price).HasColumnType("decimal(18,2)");
            });
            //seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "A", Price = 5 },
                new Product { Id = 2, Name = "B", Price = 6 }
                );
        }
    }
}
