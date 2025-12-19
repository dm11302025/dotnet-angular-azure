using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
namespace FnClient
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            var client = new HttpClient();

            var response =  client.GetAsync(
                "http://localhost:7029/api/GetEmployees");
            List<Employee>? employees = JsonConvert.DeserializeObject<List<Employee>>( response.Result.Content.ReadAsStringAsync().Result);
            if (employees != null)
            {
                foreach (var item in employees)
                {
                    Console.WriteLine($"" +
                        $"Id:{item.Id}" +
                        $" Name:{item.Name}" +
                        $" Salary:{item.Salary}" +
                        $" Designation:{item.Designation}" +
                        $" JoinDate:{item.JoinDate}");
                }
            }
        }
    }
}
