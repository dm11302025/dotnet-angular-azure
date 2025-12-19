
namespace HelloFnConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(" http://localhost:7087/api/HelloFunction?name=Virat").Result;
            Console.WriteLine(response);
        }
    }
}
