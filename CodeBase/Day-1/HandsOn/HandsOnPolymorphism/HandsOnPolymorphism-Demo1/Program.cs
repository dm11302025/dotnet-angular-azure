namespace HandsOnPolymorphism_MethodOverloading
{
    public class Calculator
    {
        // Add two integers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Add three integers (overloaded)
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Add two doubles (overloaded)
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Add(5, 10));       // Calls Add(int, int)
            Console.WriteLine(calc.Add(5, 10, 15));   // Calls Add(int, int, int)
            Console.WriteLine(calc.Add(5.5, 10.5));   // Calls Add(double, double)
        }
    }

}
