using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnClasses_StaticData
{
    internal class Employee
    {
        public int employeeId; //instance
        public string? employeeName; //instance
        public static string? organisation; //static
        public void Details()
        {
            Console.WriteLine($"Id:{employeeId} Name:{employeeName} Organization:{organisation}");
        }
    }
    class Program
    {
        static void Main()
        {
            //accessing static data
            Employee.organisation = "CTS";
            Employee e1 = new Employee() { employeeId = 33, employeeName = "Ram" };
            Employee e2 = new Employee() { employeeId = 32, employeeName = "Sita" };
            e1.Details();
            e2.Details();
            Employee.organisation = "TCS";
            Employee e3 = new Employee() { employeeId = 78, employeeName = "Karan" };
            Employee e4 = new Employee() { employeeId = 34, employeeName = "Priya" };
            e3.Details();
            e4.Details();
            e1.Details();
            
        }
    }
}
