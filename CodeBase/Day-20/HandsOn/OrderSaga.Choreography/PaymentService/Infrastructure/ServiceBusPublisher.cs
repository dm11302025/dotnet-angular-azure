using Azure.Messaging.ServiceBus;
using System.Text.Json;
namespace PaymentService.Infrastructure
{
    public class ServiceBusPublisher
    {
        private readonly ServiceBusClient _client;
        private readonly string _topicName;

        public ServiceBusPublisher(string connectionString, string topicName)
        {
            _client = new ServiceBusClient(connectionString);
            _topicName = topicName;
        }

        public async Task PublishAsync<T>(T message)
        {
            var sender = _client.CreateSender(_topicName);
            var json = JsonSerializer.Serialize(message);

            var sbMessage = new ServiceBusMessage(json)
            {
                ContentType = "application/json"
            };

            await sender.SendMessageAsync(sbMessage);
        }
    }

}
