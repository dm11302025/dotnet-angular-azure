using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnAsyncAwait
{
    //Running Multiple Async Tasks in Parallel
    internal class Demo0
    {
        static async Task Main()
        {
            //Without Async (Sequential)
            //await Task.Delay(3000);
            //await Task.Delay(3000);
            //Total = 6 seconds.
            //With Async (Parallel)
            var task1 = DoTaskAsync("Task 1");
            var task2 = DoTaskAsync("Task 2");

            await Task.WhenAll(task1, task2);//Run them in parallel
            //Both tasks run simultaneously, total time ≈ 3 seconds.
            Console.WriteLine("All done");
        }

        static async Task DoTaskAsync(string name)
        {
            Console.WriteLine($"{name} started");
            await Task.Delay(3000);
            Console.WriteLine($"{name} completed");
        }
    }
}
