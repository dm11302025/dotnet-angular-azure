using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnPolymorphism_MethodOverriding
{
    using System;

    // Base class
    public class Vehicle
    {
        public virtual void Start()
        {
            Console.WriteLine("Vehicle is starting...");
        }
    }

    // Derived class
    public class Car : Vehicle
    {
        // Override base method
        public override void Start()
        {
            Console.WriteLine("Car is starting with key ignition...");
        }
    }

    // Another derived class
    public class Bike : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Bike is starting with kick start...");
        }
    }

    class Program
    {
        static void Main()
        {
            Vehicle vehicle = new Car();   // Vehicle reference, Car object
            vehicle.Start();// Calls Car.Start() at runtime
            vehicle = new Bike();  // Vehicle reference, Bike object
            vehicle.Start();// Calls Bike.Start() at runtime
           
        }
    }

}
