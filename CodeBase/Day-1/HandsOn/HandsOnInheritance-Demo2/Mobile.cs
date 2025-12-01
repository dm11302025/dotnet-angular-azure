namespace HandsOnInheritance_Demo2
{
    // Derived product: Mobile (Multilevel Inheritance)
    public class Mobile : Electronics
    {
        public string OS { get; set; }

        public Mobile(string name, decimal price, int stock, string warranty, string os)
            : base(name, price, stock, warranty)
        {
            OS = os;
            Console.WriteLine($"Mobile OS: {OS}");
        }

        // Method hiding again
        public new void DisplayInfo()
        {
            Console.WriteLine($"Mobile: {Name}, Price: {Price:C}, Stock: {Stock}, Warranty: {Warranty}, OS: {OS}");
        }
    }

}
