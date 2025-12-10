using CleanArch.Domain.Exceptions;

namespace CleanArch.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }


        // Domain-level behavior example
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0) throw new DomainException("Price must be > 0");
            Price = newPrice;
        }
    }
}
