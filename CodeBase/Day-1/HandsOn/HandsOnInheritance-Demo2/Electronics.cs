namespace HandsOnInheritance_Demo2
{
    // Derived product: Electronics (Single Inheritance)
    public class Electronics : Product
    {
        public string Warranty { get; set; }

        public Electronics(string name, decimal price, int stock, string warranty)
            : base(name, price, stock)
        {
            Warranty = warranty;
            Console.WriteLine($"Electronics warranty: {warranty}");
        }

        // Method hiding
        public new void DisplayInfo()
        {
            Console.WriteLine($"Electronics: {Name}, Price: {Price:C}, Stock: {Stock}, Warranty: {Warranty}");
        }
    }

}
