namespace HandsOnInheritance
{
    // Single / Multilevel Inheritance
    public class Car : Vehicle
    {
        public string Model;

        public Car(string brand, string model) : base(brand)
        {
            Model = model;
            Console.WriteLine($"Car constructor called. Model: {Model}");
        }

        //// Method hiding
        public new void Start() // hides Vehicle.Start()
        {
            Console.WriteLine("Car is starting with ignition key...");
        }
    }

}
