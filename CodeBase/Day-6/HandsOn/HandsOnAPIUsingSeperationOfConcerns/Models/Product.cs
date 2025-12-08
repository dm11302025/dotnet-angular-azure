namespace HandsOnAPIUsingSeperationOfConcerns.Models
{
    //1. Model (Domain Entity) — Only Data Structure
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
