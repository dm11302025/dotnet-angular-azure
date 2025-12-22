using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace InventoryService
{
    public class OrderCreatedConsumer : BackgroundService
    {
        private readonly ServiceBusProcessor _processor;

        public OrderCreatedConsumer(IConfiguration config)
        {
            var client = new ServiceBusClient(
                config["ServiceBus:ConnectionString"]);

            _processor = client.CreateProcessor(
                config["ServiceBus:TopicName"],
                config["ServiceBus:SubscriptionName"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _processor.ProcessMessageAsync += OnMessageReceived;
            _processor.ProcessErrorAsync += ErrorHandler;

            await _processor.StartProcessingAsync(stoppingToken);
        }

        private async Task OnMessageReceived(ProcessMessageEventArgs args)
        {
            var json = args.Message.Body.ToString();
            var order = JsonSerializer.Deserialize<OrderCreatedEvent>(json);

            // Reduce inventory
            Console.WriteLine($"Reducing stock for Product {order.ProductId}");

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.Message);
            return Task.CompletedTask;
        }
    }

}
