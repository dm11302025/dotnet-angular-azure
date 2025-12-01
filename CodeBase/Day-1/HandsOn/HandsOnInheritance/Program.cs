namespace HandsOnInheritance
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== SportsCar Object ===");
            SportsCar sc = new SportsCar("Ferrari", "F8 Tributo", 340);

            // Calls hidden method in SportsCar
            sc.Start();

            // Accessing base class method explicitly
            ((Car)sc).Start();        // calls Car.Start() due to method hiding
            ((Vehicle)sc).Start();    // calls Vehicle.Start()

            Console.WriteLine("\n=== Bike Object ===");
            Bike bike = new Bike("Honda", 150);
            bike.Start(); // calls Vehicle.Start() since Bike didn't hide Start
            bike.ShowEngine();
        }
        /*
 1.Method Hiding

Car.Start() hides Vehicle.Start().

SportsCar.Start() hides Car.Start().

Use new keyword to indicate hiding.

2.Accessing Hidden Methods

By casting to base type: ((Vehicle)sc).Start();

3.Constructor & Inheritance

Base constructors are called first, then derived constructors.

Parameterized constructors flow properly using base(...).
         */
    }

}
