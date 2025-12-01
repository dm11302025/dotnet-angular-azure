using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_AnonymousMethodDemo
{
    public delegate void GreetDelegate(string name);

    class Program
    {
        static void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        static void Main()
        {
            GreetDelegate greet = SayHello;
            greet("John");
            // Anonymous method syntax
            GreetDelegate greetObj = delegate (string name)
            {
                Console.WriteLine($"Hello, {name}!");
            };

            greetObj("John");

            List<int> numbers = new List<int> { 10, 15, 20, 25, 30 };

            // Anonymous function with Predicate<int>
            Predicate<int> isEven = delegate (int n) { return n % 2 == 0; };

            List<int> evenNumbers = numbers.FindAll(isEven);

            foreach (var num in evenNumbers)
                Console.WriteLine(num);
        }
    }

}
