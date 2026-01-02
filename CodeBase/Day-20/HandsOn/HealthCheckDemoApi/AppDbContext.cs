using Microsoft.EntityFrameworkCore;
namespace HealthCheckDemoApi
{
    public class AppDbContext: DbContext    
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
