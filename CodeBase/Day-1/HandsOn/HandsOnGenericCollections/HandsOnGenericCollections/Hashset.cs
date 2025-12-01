using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_Hashset
{
    /*
     HashSet<T>

 What it is: A collection of unique items (no duplicates).

 When to use: When you need fast membership tests and uniqueness.
     */

    class Program
    {
        static void Main()
        {
            HashSet<string> countries = new HashSet<string>();
            countries.Add("India");
            countries.Add("USA");
            countries.Add("India"); // Duplicate ignored

            foreach (var c in countries)
            {
                Console.WriteLine(c);
            }
        }
    }

}
