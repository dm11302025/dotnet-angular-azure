using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates
{
    internal class FuncDelegate
    {
        static void Main()
        {
            Func<int, int, int> add = (x, y) => x + y;
            int result = add(5, 3);
            Console.WriteLine(result);
            Func<string, string> upperCase = name => name.ToUpper();
            Console.WriteLine(upperCase("chatgpt"));
            Func<double, double, double> calculateDiscount = (price, discountPercent) =>
            {
                return price - (price * discountPercent / 100);
            };

            double finalPrice = calculateDiscount(1000, 10);
            Console.WriteLine($"Final Price: {finalPrice}");
            //Func is commonly used with LINQ methods like Select, Where, etc.
            List<int> numbers = new List<int> { 1, 2, 3, 4 };
            var squared = numbers.Select(x => x * x);  // Func<int, int>

            foreach (var n in squared)
                Console.WriteLine(n);




        }
    }
}
