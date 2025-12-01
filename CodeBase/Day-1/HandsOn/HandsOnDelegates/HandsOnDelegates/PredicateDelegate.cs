using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates
{
    internal class PredicateDelegate
    {
        static void Main()
        {
            Predicate<int> isEven = n => n % 2 == 0;
            Console.WriteLine(isEven(10)); // True
            Console.WriteLine(isEven(7));  // False

            Predicate<string> isEmpty = s => string.IsNullOrWhiteSpace(s);
            Console.WriteLine(isEmpty(""));      // True
            Console.WriteLine(isEmpty("Hello")); // False

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            Predicate<int> isOdd = n => n % 2 != 0;

            List<int> oddNumbers = numbers.FindAll(isOdd);

            foreach (var num in oddNumbers)
                Console.WriteLine(num);



        }

    }
}
