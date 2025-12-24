using Azure.Messaging.ServiceBus;
using InventoryService.Repository;
using System.Text.Json;
using Shared.Contracts;
namespace InventoryService.Messaging
{
    // Background service to consume messages from the inventory queue
    public class InventoryQueueConsumer : BackgroundService
    {
        private readonly ServiceBusProcessor _processor;
        private readonly InventoryRepository _repository;

        public InventoryQueueConsumer(
            IConfiguration config,
            InventoryRepository repository)
        {
            _repository = repository;
            // Create Service Bus Client
            var client = new ServiceBusClient(
                config["ServiceBus:ConnectionString"]);

            // Create a processor for the queue
            //listen to messages from "inventory-queue"
            _processor = client.CreateProcessor("inventory-queue");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Configure the message and error handlers
            _processor.ProcessMessageAsync += ProcessMessage;
            _processor.ProcessErrorAsync += ErrorHandler;

            // Start processing messages
            // This runs until the application is stopped
            await _processor.StartProcessingAsync(stoppingToken);
        }

        // Handle incoming messages
        private async Task ProcessMessage(ProcessMessageEventArgs args)
        {
            // Deserialize the message body
            var json = args.Message.Body.ToString();
            // Convert to ReserveInventoryCommand
            var command = JsonSerializer.Deserialize<ReserveInventoryCommand>(json);

            _repository.ReduceStock(command.ProductId, command.Quantity);

            Console.WriteLine(
                $"Stock reduced for Product {command.ProductId}");

            await args.CompleteMessageAsync(args.Message);
        }

        // Handle any errors when receiving messages
        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.Message);
            return Task.CompletedTask;
        }
    }

}
