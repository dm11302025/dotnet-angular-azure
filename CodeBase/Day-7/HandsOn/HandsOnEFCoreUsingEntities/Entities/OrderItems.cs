using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandsOnEFCoreUsingEntities.Entities
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Order Orders { get; set; }
        public Product Products { get; set; }
    }
}
