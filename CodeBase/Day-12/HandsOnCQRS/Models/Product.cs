namespace HandsOnCQRS.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public void Update(string name, decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Invalid price");

            Name = name;
            Price = price;
        }

    }

}
