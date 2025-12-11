using System;
using System.Threading;
namespace HandsOnAsyncAwait_Synchronous
{
    //Synchronous (Blocking)
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting…");
            DoWork();
            Console.WriteLine("Finished");
        }

        static void DoWork()
        {
            // The entire thread pauses for 3 seconds.
            Thread.Sleep(3000); // blocking for 3 seconds
            Console.WriteLine("Work Completed");
        }
    }


}
namespace HandsOnAsyncAwait_ASynchronous
{
    //ASynchronous ((Non-Blocking))
    class Program   
    {
        static async Task Main()
        {
            Console.WriteLine("Starting…");
            await DoWorkAsync();
            Console.WriteLine("Finished");
        }

        static async Task DoWorkAsync()
        {
            //Task.Delay is non-blocking, so the main thread is free to do other work.
            //await releases the thread to the runtime instead of blocking it.
            await Task.Delay(3000); // non-blocking delay
            Console.WriteLine("Work Completed");
        }
    }


}
