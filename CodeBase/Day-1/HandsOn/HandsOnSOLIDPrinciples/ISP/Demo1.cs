using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnSOLIDPrinciples.ISP
{
    //Without ISP
    //public interface IWorker
    //{
    //    void Work();
    //    void Eat();
    //    void Sleep();
    //}

    //public class HumanWorker : IWorker
    //{
    //    public void Work()
    //    {
    //        Console.WriteLine("Human is working...");
    //    }

    //    public void Eat()
    //    {
    //        Console.WriteLine("Human is eating lunch...");
    //    }
    //    public void Sleep()
    //    {
    //        Console.WriteLine("Human is sleeping...");
    //    }
    //}

    //public class RobotWorker : IWorker
    //{
    //    public void Work()
    //    {
    //        Console.WriteLine("Robot is working...");
    //    }

    //    public void Eat()
    //    {
    //        // ❌ Robots don’t eat, but we are forced to implement this
    //        throw new NotImplementedException("Robots don’t eat!");
    //    }
    //    public void Sleep()
    //    {
    //        // ❌ Robots don’t sleep, but we are forced to implement this
    //        throw new NotImplementedException("Robots don’t sleep!");
    //    }
    //}
    /*
     ❌ What’s wrong here?

The interface IWorker has too many responsibilities.

RobotWorker doesn’t need Eat(), but it’s forced to implement it.

This makes the design confusing and fragile.
     */
    //With ISP
    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    // Humans need both
    public class HumanWorker : IWorkable, IEatable
    {
        public void Work()
        {
            Console.WriteLine("Human is working...");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating lunch...");
        }
    }

    // Robots only work
    public class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot is working...");
        }
    }

}
