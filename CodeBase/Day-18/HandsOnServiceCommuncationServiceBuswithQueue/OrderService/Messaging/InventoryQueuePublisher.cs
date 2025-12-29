using Azure.Messaging.ServiceBus;
using Shared.Contracts;
using System.Text.Json;
namespace OrderService.Messaging
{
    public class InventoryQueuePublisher
    {
        private readonly ServiceBusSender _sender;

        public InventoryQueuePublisher(IConfiguration configuration)
        {
            // Create a Service Bus client
            var client = new ServiceBusClient(
                configuration["ServiceBus:ConnectionString"]);

            // Create a sender for the queue
            //send messages to "inventory-queue"
            _sender = client.CreateSender(
                configuration["ServiceBus:QueueName"]);
        }

        public async Task SendAsync(ReserveInventoryCommand command)
        {
            // Serialize the command to JSON
            var json = JsonSerializer.Serialize(command);
            // Create a Service Bus message
            var message = new ServiceBusMessage(json)
            {
                Subject = "ReserveInventory"
            };
            // Send the message to the queue
            // sending message to "inventory-queue"(ServiceBus:QueueName)
            await _sender.SendMessageAsync(message);
        }
    }
}
