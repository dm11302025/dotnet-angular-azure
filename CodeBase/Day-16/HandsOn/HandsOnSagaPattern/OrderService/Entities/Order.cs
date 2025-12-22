namespace OrderService.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; } // Pending, Completed, Cancelled
    }

}
