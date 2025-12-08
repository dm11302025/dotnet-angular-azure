using HandsOnAPIUsingEFDemo_1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
namespace HandsOnAPIUsingEFDemo_1.DataProvider
{
    //Dbcontext class
    public class ApplicationContext:DbContext
    {
        //define constructor when declare conncetionstring in appsettings.json
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
: base(options)
        {
        }
        //define entity set
        public DbSet<Employee> Employees { get; set; }
        //define the connection string
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        //}

    }
}
