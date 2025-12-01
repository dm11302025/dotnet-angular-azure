using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo1
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter a number:");
                int num = int.Parse(Console.ReadLine());  // may throw FormatException
                Console.WriteLine($"You entered: {num}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution finished (finally block always runs).");
            }
        }
    }

}
