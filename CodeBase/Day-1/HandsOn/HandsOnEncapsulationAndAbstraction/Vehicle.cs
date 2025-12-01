using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnAbstraction
{
    //Abstraction Example
    // Abstract class defines *what* methods should exist
    public abstract class Vehicle
    {
        public abstract void Start();
        public abstract void Stop();
    }

    // Concrete class provides *how* methods work
    public class Car : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Car started with key ignition.");
        }

        public override void Stop()
        {
            Console.WriteLine("Car stopped using brakes.");
        }
    }

    public class Bike : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Bike started with self-start button.");
        }

        public override void Stop()
        {
            Console.WriteLine("Bike stopped using hand brakes.");
        }
    }

    class Program
    {
        static void Main()
        {
            Vehicle myCar = new Car();
            Vehicle myBike = new Bike();

            myCar.Start();
            myCar.Stop();

            myBike.Start();
            myBike.Stop();
            /*
             ✔ Here, Vehicle provides an abstract definition of what all vehicles 
            should do (Start, Stop) but hides the implementation details.
                    Each subclass (Car, Bike) provides its own implementation.
             */
        }
    }

}
