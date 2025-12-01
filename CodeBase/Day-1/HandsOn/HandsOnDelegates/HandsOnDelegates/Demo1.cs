using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_Demo1
{
    public delegate int MathOperation(int x, int y);

    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Multiply(int a, int b) => a * b;
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            MathOperation op = calc.Add;
            op += calc.Multiply;

            int result = op(2, 3);
            Console.WriteLine(result);  // Output: 6 (Multiply result)
        }
    }

}
