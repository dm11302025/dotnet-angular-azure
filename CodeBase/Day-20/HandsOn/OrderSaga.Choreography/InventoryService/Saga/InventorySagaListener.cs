using Azure.Messaging.ServiceBus;
using InventoryService.Infrastructure;
using System.Text.Json;
using Shared.Contracts.Events;
namespace InventoryService.Saga
{
   public class InventorySagaListener : BackgroundService
{
    private readonly ServiceBusProcessor _processor;
    private readonly ServiceBusPublisher _publisher;
    private readonly ILogger<InventorySagaListener> _logger;

    public InventorySagaListener(
        ServiceBusClient client,
        ServiceBusPublisher publisher,
        ILogger<InventorySagaListener> logger)
    {
        _processor = client.CreateProcessor("order-saga-topic", "inventory-service-sub");
        _publisher = publisher;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Inventory Service listener started...");
        _processor.ProcessMessageAsync += Handle;
        _processor.ProcessErrorAsync += Error;
        await _processor.StartProcessingAsync(stoppingToken);
    }

    private async Task Handle(ProcessMessageEventArgs args)
    {
        var body = args.Message.Body.ToString();
        _logger.LogInformation("Inventory Service received message: {Message}", body);

        if (body.Contains("PaymentCompleted"))
        {
            _logger.LogInformation("Reserving inventory...");

            var evt = JsonSerializer.Deserialize<PaymentCompletedEvent>(body);

            await _publisher.PublishAsync(new InventoryReservedEvent
            {
                OrderId = evt!.OrderId,
                CorrelationId = evt.CorrelationId
            });

            _logger.LogInformation(
                "Inventory reserved for OrderId {OrderId}", evt.OrderId);
        }

        await args.CompleteMessageAsync(args.Message);
    }

    private Task Error(ProcessErrorEventArgs args)
    {
        _logger.LogError(args.Exception, "Inventory Service error");
        return Task.CompletedTask;
    }
}


}
