using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HandsOnAPIUsingEFCodeFirst.Entities
{
    public class Order
    {
        [Key] //primary key
        public Guid Id { get; set; } //applied primary key constraint
        public DateTime OrderDate { get; set; } //applied not null constraint
        public string? UserId { get; set; } = ""; //applied null constraint with foreign key
        public int? ProductId { get; set; } //applied null constraint with foreign key
        public decimal? TotalAmount { get; set; } //applied null constraint
        // Navigation properties
        [ForeignKey("UserId")]
        public User? User { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
