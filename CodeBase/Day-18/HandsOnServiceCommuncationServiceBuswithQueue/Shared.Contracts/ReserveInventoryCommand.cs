namespace Shared.Contracts
{
    public class ReserveInventoryCommand
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
