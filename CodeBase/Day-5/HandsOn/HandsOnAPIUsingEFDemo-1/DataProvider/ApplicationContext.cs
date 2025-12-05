using HandsOnAPIUsingEFDemo_1.Entities;
using Microsoft.EntityFrameworkCore;
namespace HandsOnAPIUsingEFDemo_1.DataProvider
{
    //Dbcontext class
    public class ApplicationContext:DbContext
    {
        //define entity set
        public DbSet<Employee> Employees { get; set; }
        //define the connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

    }
}
