using System.ComponentModel.DataAnnotations;

namespace HandsOnAPIUsingStatusCodes.DTOs
{
    public class CreateAccountDto
    {
        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string HolderName { get; set; }

        public decimal InitialBalance { get; set; }
    }
}
