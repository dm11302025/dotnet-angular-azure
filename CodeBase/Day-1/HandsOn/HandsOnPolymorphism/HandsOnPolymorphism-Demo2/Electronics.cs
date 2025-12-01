namespace HandsOnPolymorphism_Demo2
{
    using System;

    // Derived class: Electronics (single inheritance)
    public class Electronics : Product
    {
        public string Warranty { get; set; }

        public Electronics(string name, decimal price, int stock, string warranty)
            : base(name, price, stock)
        {
            Warranty = warranty;
            Console.WriteLine($"Electronics warranty: {Warranty}");
        }

        // Method hiding
        public new void DisplayInfo()
        {
            Console.WriteLine($"Electronics: {Name}, Price: {Price:C}, Stock: {Stock}, Warranty: {Warranty}");
        }
    }

}
