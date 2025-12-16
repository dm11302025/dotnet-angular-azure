using HandsOnAPIUsingEFDemo_1.DataProvider;
using HandsOnAPIUsingEFDemo_1.Repositories;
using Microsoft.EntityFrameworkCore;
namespace HandsOnAPIUsingEFDemo_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //configure the connectionstring
            builder.Services.AddDbContext<ApplicationContext>
                (options=>options.UseSqlServer(connection));
            //Register Service
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
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
