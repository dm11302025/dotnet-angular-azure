using HandsOnEFCoreLazyAndEagerLoading.Models;
using Microsoft.EntityFrameworkCore;
                                
namespace HandsOnEFCoreLazyAndEagerLoading.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department → Employees (One-to-Many)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed some data
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "IT" },
                new Department { DepartmentId = 2, Name = "Accounts" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 101, FullName = "Ravi Kumar", DepartmentId = 1 },
                new Employee { EmployeeId = 102, FullName = "Meena Sharma", DepartmentId = 1 },
                new Employee { EmployeeId = 201, FullName = "Arjun Patel", DepartmentId = 2 }
            );
        }
  
    }
}
