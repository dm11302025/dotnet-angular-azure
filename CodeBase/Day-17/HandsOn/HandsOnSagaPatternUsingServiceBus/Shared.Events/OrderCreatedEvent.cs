namespace Shared.Events
{
    public record OrderCreatedEvent(int OrderId, int ProductId, int Quantity, decimal Amount);
}
