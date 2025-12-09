using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HandsOnEFCoreUsingEntities.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //Navigation Properties
        public Product Product { get; set; }
        public User User { get; set; }
       
    }
}
