using Microsoft.EntityFrameworkCore;
using HandsOnAPIUsingEFCodeFirst.Entities;
namespace HandsOnAPIUsingEFCodeFirst.Data
{
    public class ClickCartContext : DbContext
    {
        //Step 1: Create a class that inherits from DbContext
        public ClickCartContext(DbContextOptions<ClickCartContext> options) : base(options)
        {
        }
        //Step 2: Create a constructor that takes DbContextOptions and passes it to the base class constructor
        public DbSet<User> Users { get; set; }//entity set for User
        public DbSet<Product> Products { get; set; } //entity set for Product
        public DbSet<Order> Orders { get; set; } //entity set for Order
        //Step 3: Create DbSet properties for each entity class
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Step 4: Override OnConfiguring to set up the database connection (optional if using dependency injection)
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=ClickCartDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Step 4: Override OnModelCreating to configure the model (optional)
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            //seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Price = 999.99M },
                new Product { ProductId = 2, Name = "Smartphone", Price = 499.99M },
                new Product { ProductId = 3, Name = "Tablet", Price = 299.99M }
            );
            //seed data for Users 
            modelBuilder.Entity<User>().HasData(
                new User { Id = "user1", UserName = "Alice", Email = "alice@gmail.com", Mobile = "1234567890", PasswordHash = "12345" },
                new User { Id = "user2", UserName = "Bob", Email = "bob@gmail.com", Mobile = "0987654321", PasswordHash = "54321" }

                );
            //seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = new Guid("19ea4544-a179-470f-894b-0021af25b1ec"), OrderDate =DateTime.Parse("12.2.2024"), UserId = "user1", ProductId = 1, TotalAmount = 999.99M },
                new Order { Id = new Guid("21de863d-aba5-452c-b235-0d6d55436020"), OrderDate = DateTime.Parse("12.2.2025"), UserId = "user2", ProductId = 2, TotalAmount = 499.99M }
                );
            //Step 5: Use Fluent API to configure entity properties and relationships (optional)

        }
    }
}
