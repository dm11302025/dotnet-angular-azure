
using HandsOnAPIUsingEFCodeFirst.Data;
using HandsOnAPIUsingEFCodeFirst.Repositories;
using HandsOnAPIUsingEFCodeFirst.Services;
using Microsoft.EntityFrameworkCore;
namespace HandsOnAPIUsingEFCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //configure cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin() // allow requests from any origin
                               .AllowAnyMethod() // allow any HTTP method
                               .AllowAnyHeader(); // allow any headers
                    });
            });
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ClickCartDBConnection");
            builder.Services.AddDbContext<ClickCartContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
