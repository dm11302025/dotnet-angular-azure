using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnAsyncAwait
{
    //When CPU work is heavy, wrap it using Task.Run to offload from the main thread.
    internal class Demo5
    {
        static async Task Main()
        {
            Console.WriteLine("Calculating...");
            //int result = Calculate();// Synchronous call
            int result = await Task.Run(() => Calculate()); // Asynchronous call
            Console.WriteLine($"Result: {result}");
        }

        static int Calculate()
        {
            int total = 0;
            for (int i = 0; i < 500000000; i++)
                total++;
            return total;
        }
    }
}
// Without async, the Main method blocks until Calculate completes
// With async, the Main method can continue executing while Calculate runs in the background
// This improves responsiveness, especially in UI applications
//Task.Run executes on a background thread
//Main thread isn’t blocked