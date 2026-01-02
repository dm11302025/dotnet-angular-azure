
using Azure.Messaging.ServiceBus;
using InventoryService.Infrastructure;
using InventoryService.Saga;

namespace InventoryService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton(
    new ServiceBusClient(builder.Configuration["ServiceBus:ConnectionString"]));

            builder.Services.AddSingleton(sp =>
                new ServiceBusPublisher(
                    builder.Configuration["ServiceBus:ConnectionString"],
                    "order-saga-topic"));

            builder.Services.AddHostedService<InventorySagaListener>(); // or Payment/Inventory

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
