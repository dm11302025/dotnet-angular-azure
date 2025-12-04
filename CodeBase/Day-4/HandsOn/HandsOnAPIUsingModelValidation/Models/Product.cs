using System.ComponentModel.DataAnnotations;

namespace HandsOnAPIUsingModelValidation.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(0, 500)]
        public int Stock { get; set; }
    }

}
