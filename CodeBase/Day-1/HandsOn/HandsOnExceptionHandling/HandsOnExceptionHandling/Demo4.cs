using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo4
{
    /*
     *What is a Nested Exception?

 A nested exception (also called an inner exception) happens when:

 You catch one exception,

 Wrap it inside another exception (adding extra context),

 Then throw the new exception while keeping the original exception details.

 This way, the outer exception carries the inner exception with full stack trace.
 It’s very useful when you want to provide more context without losing the root cause.
     */

    class Program
    {
        static void Main()
        {
            try
            {
                ProcessOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught in Main:");
                Console.WriteLine($"Message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }

        static void ProcessOrder()
        {
            try
            {
                int[] arr = { 1, 2, 3 };
                Console.WriteLine(arr[5]);  // throws IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                // Wrap original exception into a new one
                throw new ApplicationException("Order processing failed", ex);
            }
        }
    }
    /* Caught in Main:
    Message: Order processing failed
    Inner Exception: Index was outside the bounds of the array.*/
}
