using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo6
{
    /*
     What is Rethrowing?

 When you catch an exception, sometimes you only want to:

 Log it, or

 Add some context,

 … and then pass it up to the caller.
 This is called rethrowing the exception.

 There are two main ways in C#:

 throw; ✅ (best way — preserves stack trace)

 throw ex; ❌ (bad practice — resets stack trace)
     */
    using System;

    class Program
    {
        static void Main()
        {
            try
            {
                Method1();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught in Main:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace:\n{ex.StackTrace}");
            }
        }

        static void Method1()
        {
            try
            {
                Method2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logging in Method1...");
                // Rethrow the same exception (stack trace is preserved)
                throw;
            }
        }

        static void Method2()
        {
            // This will throw
            int x = 10, y = 0;
            int result = x / y;  // DivideByZeroException
        }
    }

}
