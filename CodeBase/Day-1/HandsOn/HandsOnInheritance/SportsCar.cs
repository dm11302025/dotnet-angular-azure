namespace HandsOnInheritance
{
    // Multilevel Inheritance
    public class SportsCar : Car
    {
        public int TopSpeed;

        public SportsCar(string brand, string model, int topSpeed) : base(brand, model)
        {
            TopSpeed = topSpeed;
            Console.WriteLine($"SportsCar constructor called. Top Speed: {TopSpeed} km/h");
        }

        // Method hiding again
        public new void Start()
        {
            Console.WriteLine("SportsCar is starting with push-button ignition...");
        }
    }

}
