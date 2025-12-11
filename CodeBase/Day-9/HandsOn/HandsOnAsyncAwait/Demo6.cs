using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnAsyncAwait
{
    //Returning Data with Task<T> Simulating asynchronous data retrieval with Task.Delay
    internal class Demo6
    {
        static async Task Main()
        {
            string data = await GetDataAsync();
            Console.WriteLine($"Data Received: {data}");
        }

        static async Task<string> GetDataAsync()
        {
            await Task.Delay(2000);
            return "Hello, async world!";
        }
    }
}
