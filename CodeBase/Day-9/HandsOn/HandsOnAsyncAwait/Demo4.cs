using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Added missing namespace for StreamReader

namespace HandsOnAsyncAwait
{
    internal class Demo4
    {
        static async Task Main()
        {
            Console.WriteLine("Calling API…");
            string result = await GetDataAsync();
            Console.WriteLine($"Received: {result}...");
        }

        static async Task<string> GetDataAsync()
        {
            using var client = new HttpClient();
            return await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
        }
    }
}
//API call is non-blocking
//Main method continues executing while waiting for the API response