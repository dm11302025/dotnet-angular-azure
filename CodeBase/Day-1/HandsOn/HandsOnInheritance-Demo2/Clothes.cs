namespace HandsOnInheritance_Demo2
{
    // Hierarchical Inheritance: Clothes
    public class Clothes : Product
    {
        public string Size { get; set; }

        public Clothes(string name, decimal price, int stock, string size) : base(name, price, stock)
        {
            Size = size;
            Console.WriteLine($"Clothes size: {Size}");
        }
    }

}
