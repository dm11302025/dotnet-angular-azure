using Azure.Messaging.ServiceBus;
using Shared.Contracts;
using System.Text.Json;
namespace OrderService.Messaging
{
    public class OrderEventPublisher
    {
        private readonly ServiceBusSender _sender;

        public OrderEventPublisher(IConfiguration config)
        {
            var client = new ServiceBusClient(
                config["ServiceBus:ConnectionString"]);

            _sender = client.CreateSender(
                config["ServiceBus:TopicName"]);
        }

        public async Task PublishOrderCreatedAsync(OrderCreatedEvent orderEvent)
        {
            var messageBody = JsonSerializer.Serialize(orderEvent);

            var message = new ServiceBusMessage(messageBody)
            {
                Subject = "OrderCreated"
            };

            await _sender.SendMessageAsync(message);
        }
    }

}
