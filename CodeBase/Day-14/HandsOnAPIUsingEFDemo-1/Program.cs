using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using HandsOnAPIUsingEFDemo_1.DataProvider;
using HandsOnAPIUsingEFDemo_1.Repositories;
using Microsoft.EntityFrameworkCore;
namespace HandsOnAPIUsingEFDemo_1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
          

            var builder = WebApplication.CreateBuilder(args);

            // Add Key Vault as Configuration Source
            var keyVaultUrl = builder.Configuration["KeyVaultUrl"];
            if (!string.IsNullOrEmpty(keyVaultUrl))
            {
                builder.Configuration.AddAzureKeyVault(
                    new Uri(keyVaultUrl),
                    new DefaultAzureCredential());
            }

            // DbContext
            //var cs = builder.Configuration.GetConnectionString("DefaultConnection");
            //if (string.IsNullOrWhiteSpace(cs))
            //{
            //    throw new Exception("Connection string NOT resolved from Key Vault");
            //}
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // DI
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
