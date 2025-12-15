
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace EComm.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add Ocelot configuration file
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            // Add Ocelot services
            builder.Services.AddOcelot();
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
            app.UseOcelot(); // Use Ocelot middleware
            app.Run();
        }
    }
}
