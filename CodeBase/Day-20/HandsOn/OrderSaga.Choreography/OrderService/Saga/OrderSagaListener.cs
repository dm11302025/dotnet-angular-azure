using Azure.Messaging.ServiceBus;
using OrderService.Domain;
using Shared.Contracts;
using Shared.Contracts.Events;
using System.Text.Json;

namespace OrderService.Saga
{
    public class OrderSagaListener : BackgroundService
    {
        private readonly ServiceBusProcessor _processor;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<OrderSagaListener> _logger;

        public OrderSagaListener(
            ServiceBusClient client,
            IServiceScopeFactory scopeFactory,
            ILogger<OrderSagaListener> logger)
        {
            _processor = client.CreateProcessor(
                "order-saga-topic",
                "order-service-sub");

            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Order Service listener started...");

            _processor.ProcessMessageAsync += Handle;
            _processor.ProcessErrorAsync += Error;

            await _processor.StartProcessingAsync(stoppingToken);
        }

        private async Task Handle(ProcessMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();

            using var document = JsonDocument.Parse(body);
            var eventType = document.RootElement
                                    .GetProperty("EventType")
                                    .GetString();

            _logger.LogInformation(
                "Order Service received event: {EventType}", eventType);

            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider
                          .GetRequiredService<OrderDbContext>();

            switch (eventType)
            {
                case "InventoryReserved":
                    var reserved =
                        JsonSerializer.Deserialize<InventoryReservedEvent>(body)!;

                    var order = await db.Orders.FindAsync(reserved.OrderId);
                    order!.Status = "Completed";

                    _logger.LogInformation(
                        "Order {OrderId} marked as Completed",
                        reserved.OrderId);
                    break;

                case "PaymentFailed":
                    var paymentFailed =
                        JsonSerializer.Deserialize<PaymentFailedEvent>(body)!;

                    var order1 = await db.Orders.FindAsync(paymentFailed.OrderId);
                    order1!.Status = "Cancelled";

                    _logger.LogInformation(
                        "Order {OrderId} cancelled due to payment failure",
                        paymentFailed.OrderId);
                    break;

                case "InventoryFailed":
                    var inventoryFailed =
                        JsonSerializer.Deserialize<InventoryFailedEvent>(body)!;

                    var order2 = await db.Orders.FindAsync(inventoryFailed.OrderId);
                    order2!.Status = "Cancelled";

                    _logger.LogInformation(
                        "Order {OrderId} cancelled due to inventory failure",
                        inventoryFailed.OrderId);
                    break;

            }

            await db.SaveChangesAsync();
            await args.CompleteMessageAsync(args.Message);
        }

        private Task Error(ProcessErrorEventArgs args)
        {
            _logger.LogError(args.Exception, "Order Service error");
            return Task.CompletedTask;
        }
    }


}
