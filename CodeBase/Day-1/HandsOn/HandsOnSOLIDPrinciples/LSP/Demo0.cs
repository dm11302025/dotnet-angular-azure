using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnSOLIDPrinciples.LSP_Demo0
{


    #region Violates LSP
    //public class Bird
    //{
    //    public virtual void Fly()
    //    {
    //        Console.WriteLine("Bird is flying...");
    //    }
    //}

    //public class Sparrow : Bird
    //{
    //    public override void Fly()
    //    {
    //        Console.WriteLine("Sparrow is flying...");
    //    }
    //}

    //public class Penguin : Bird
    //{
    //    public override void Fly()
    //    {
    //        // ❌ Penguins can’t fly!
    //        throw new Exception("Penguins can't fly!");
    //    }
    //}
    /*
     What’s wrong here?

Penguin is a Bird, but it doesn’t behave like other birds (can’t fly).

If we substitute a Penguin where a Bird is expected, our program breaks.

Example:

Bird bird = new Penguin();
bird.Fly(); // ❌ Throws Exception


This violates LSP, because the child class changed the expected behavior of the base class.
     */
    #endregion

    public abstract class Bird
    {
        public abstract void Move();
    }

    public class Sparrow : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Sparrow is flying...");
        }
    }

    public class Penguin : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Penguin is swimming...");
        }
    }
    class Program
    {
        static void Main()
        {
            List<Bird> birds = new List<Bird>
                        {
                            new Sparrow(),
                            new Penguin()
                        };

            foreach (var bird in birds)
            {
                bird.Move(); // Works correctly for both
            }
        }
    }

}
