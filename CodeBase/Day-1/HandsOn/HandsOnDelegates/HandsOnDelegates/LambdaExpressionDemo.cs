using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_LambdaExpressionDemo
{
    public delegate void GreetDelegate(string name);
    public delegate int MathOperation(int a, int b);

    class Program
    {
        static void Main()
        {
            //basic lambda
            GreetDelegate greet = (name) => Console.WriteLine($"Hello, {name}!");
            greet("Alice");
            //lambda with return value
            MathOperation add = (a, b) => a + b;
            MathOperation multiply = (a, b) => a * b;

            Console.WriteLine(add(5, 3));       // 8
            Console.WriteLine(multiply(5, 3));  // 15

            List<string> names = new List<string> { "Ravi", "Rahul", "Raj", "Mohan" };

            // Using lambda (anonymous function)
            var filtered = names.Where(name => name.StartsWith("R"));

            foreach (var name in filtered)
                Console.WriteLine(name);
        }
    }

}
