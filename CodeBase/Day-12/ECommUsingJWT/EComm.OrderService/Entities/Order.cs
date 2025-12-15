namespace EComm.OrderService.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
