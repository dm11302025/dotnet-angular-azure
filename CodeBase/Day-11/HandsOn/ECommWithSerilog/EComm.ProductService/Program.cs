using Microsoft.EntityFrameworkCore;
using EComm.ProductService.Data;
using Serilog;
namespace EComm.ProductService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("ProductDbConnection");
            builder.Services.AddDbContext<ProductDbContext>
                (options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<Services.IProductService, Services.ProductService>();
            builder.Services.AddTransient<Repositories.IProductRepository, Repositories.ProductRepository>();
            Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Information()
     .Enrich.FromLogContext()
     .Enrich.WithProperty("ServiceName", "ProductAPI")
     .WriteTo.Console()
     .WriteTo.Seq("http://localhost:5341")
     .CreateLogger();

            builder.Host.UseSerilog();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseSerilogRequestLogging();
            // Configure the HTTP request pipeline.
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
