using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnAsyncAwait
{
    internal class Demo1
    {
        static async Task LongProcess()
        {
            Console.WriteLine("LongProcess Started");

            await Task.Delay(4000); // hold execution for 4 seconds

            Console.WriteLine("LongProcess Completed");

        }
        static async Task ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");

            //do something here
            await Task.Delay(2000);

            Console.WriteLine("ShortProcess Completed");
        }
        static async Task Main(string[] args)
        {
            Task longTask = LongProcess();
            Task shortTask = ShortProcess();
            //WhenAll waits for all the provided tasks to complete
            await Task.WhenAll(longTask, shortTask); // wait for both tasks to complete
            Console.ReadKey();
            
        }
    }
}
