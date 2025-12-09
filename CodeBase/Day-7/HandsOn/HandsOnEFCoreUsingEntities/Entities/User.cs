using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HandsOnEFCoreUsingEntities.Entities
{
    public class User
    {
        [Key] // Primary Key
        [Column(TypeName ="char")]
        [StringLength(4)]
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        // public IEnumerable<Order> Orders { get; set; }
    }
}
