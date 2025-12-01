using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_ActionDelegate
{
    internal class ActionDelegate
    {
        //You can pass an Action to another method as a callback:
        static void ProcessData(Action onComplete) 
        {
            Console.WriteLine("Processing...");
            Thread.Sleep(2000);
            onComplete();
        }
        static void Main()
        {
            //single parameter
            Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
            greet("John");
            //multiple parameters
            Action<int, int> printSum = (a, b) => Console.WriteLine($"Sum = {a + b}");
            printSum(5, 3);
            ProcessData(() => Console.WriteLine("Processing complete!"));


        }
    }
}
