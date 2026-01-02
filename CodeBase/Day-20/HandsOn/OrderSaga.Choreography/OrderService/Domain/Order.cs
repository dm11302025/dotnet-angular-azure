namespace OrderService.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
