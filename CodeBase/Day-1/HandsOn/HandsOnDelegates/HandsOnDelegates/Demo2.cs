using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_Demo2
{
    public delegate void Operation(int x, int y);
    //To Pass Methods as Parameters
    public class Calculator
    {
        public void Execute(Operation op, int a, int b)
        {
            op(a, b);//invoking delegate
        }

        public void Add(int x, int y) => Console.WriteLine(x + y);
        public void Subtract(int x, int y) => Console.WriteLine(x - y);
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();

            // Passing different methods dynamically
            calc.Execute(calc.Add, 10, 5);       // Output: 15
            calc.Execute(calc.Subtract, 10, 5);  // Output: 5
            //You can write one general method (Execute) that can perform any operation —
            //the actual operation is passed at runtime.
        }
    }

}
