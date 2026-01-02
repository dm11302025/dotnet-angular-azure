using Azure.Messaging.ServiceBus;
using PaymentService.Infrastructure;
using Shared.Contracts;
using Shared.Contracts.Events;
using System.Text.Json;
namespace PaymentService.Saga
{
    public class PaymentSagaListener : BackgroundService
    {
        private readonly ServiceBusProcessor _processor;
        private readonly ServiceBusPublisher _publisher;
        private readonly ILogger<PaymentSagaListener> _logger;

        public PaymentSagaListener(
            ServiceBusClient client,
            ServiceBusPublisher publisher,
            ILogger<PaymentSagaListener> logger)
        {
            _processor = client.CreateProcessor("order-saga-topic", "payment-service-sub");
            _publisher = publisher;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Payment Service listener started...");
            _processor.ProcessMessageAsync += Handle;
            _processor.ProcessErrorAsync += Error;
            await _processor.StartProcessingAsync(stoppingToken);
        }

        private async Task Handle(ProcessMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();

            using var document = JsonDocument.Parse(body);
            var eventType = document.RootElement.GetProperty("EventType").GetString();

            _logger.LogInformation(
                "Payment Service received event: {EventType}", eventType);

            switch (eventType)
            {
                case "OrderCreated":
                    var orderCreated =
                        JsonSerializer.Deserialize<OrderCreatedEvent>(body)!;

                    _logger.LogInformation("Processing payment...");

                    await _publisher.PublishAsync(new PaymentCompletedEvent
                    {
                        OrderId = orderCreated.OrderId,
                        CorrelationId = orderCreated.CorrelationId
                    });

                    _logger.LogInformation(
                        "Payment completed for OrderId {OrderId}",
                        orderCreated.OrderId);
                    break;

                case "InventoryFailed":
                    var inventoryFailed =
                        JsonSerializer.Deserialize<InventoryFailedEvent>(body)!;

                    _logger.LogInformation(
                        "Refunding payment for OrderId {OrderId}",
                        inventoryFailed.OrderId);

                    await _publisher.PublishAsync(new PaymentRefundedEvent
                    {
                        OrderId = inventoryFailed.OrderId,
                        CorrelationId = inventoryFailed.CorrelationId
                    });
                    break;

            }

            await args.CompleteMessageAsync(args.Message);
        }



        private Task Error(ProcessErrorEventArgs args)
        {
            _logger.LogError(args.Exception, "Payment Service error");
            return Task.CompletedTask;
        }
    }


}
