
using HandsOnEFCoreLazyAndEagerLoading.Data;
using Microsoft.EntityFrameworkCore;

namespace HandsOnEFCoreLazyAndEagerLoading
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Enable Lazy Loading (optional)
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //    options.UseLazyLoadingProxies()
            //           .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //builder.Services.AddControllers();
            // To handle potential reference loops in JSON serialization
            //If a cycle is detected, ignore the repeated reference instead of crashing.
            // This is particularly useful in entity relationships that reference each other.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });
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
