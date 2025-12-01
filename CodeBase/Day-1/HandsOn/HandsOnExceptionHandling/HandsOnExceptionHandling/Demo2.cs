using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo2
{
    class Program
    {
        static void Main()
        {
            try
            {
                int x = 10, y = 0;
                int result = x / y;  // throws DivideByZeroException
            }
            catch (ArithmeticException ex)   // base class for math errors
            {
                Console.WriteLine($"Math error: {ex.Message}");
            }
            catch (Exception ex)             // generic fallback
            {
                Console.WriteLine($"Other error: {ex.Message}");
            }


        }
    }

}
