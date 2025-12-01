namespace HandsOnInheritance
{
    // Base class
    public class Vehicle
    {
        public string Brand;

        public Vehicle(string brand)
        {
            Brand = brand;
            Console.WriteLine($"Vehicle constructor called. Brand: {Brand}");
        }

        // Normal method
        public void Start()
        {
            Console.WriteLine("Vehicle is starting...");
        }
    }

}
