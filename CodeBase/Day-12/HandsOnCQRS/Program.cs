using HandsOnCQRS.CommandHandlers;
using HandsOnCQRS.QueryHandlers;
using Microsoft.EntityFrameworkCore;
namespace HandsOnCQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Configure Connection String
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Data.ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            //Dependency Injection for Repositories
            builder.Services.AddScoped<Repositories.IProductRepository, Repositories.ProductRepository>();
            builder.Services.AddScoped<CreateProductCommandHandler>();
            builder.Services.AddScoped<UpdateProductCommandHandler>();
            builder.Services.AddScoped<DeleteProductCommandHandler>();
            builder.Services.AddScoped<GetAllProductsQueryHandler>();
            builder.Services.AddScoped<GetProductByIdQueryHandler>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
