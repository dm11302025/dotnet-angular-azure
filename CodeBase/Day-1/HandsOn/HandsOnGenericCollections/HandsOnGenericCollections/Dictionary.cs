using HandsOnGenericCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_Dictionary
{
    /*
     2. Dictionary<TKey, TValue>

  What it is: A collection of key-value pairs.

  When to use: When you need fast lookup based on a unique key.

  Note: Keys must be unique.
     */
    class Program
    {
        static void Main()
        {
            Dictionary<int, string> employeeDirectory = new Dictionary<int, string>();
            employeeDirectory.Add(101, "John");
            employeeDirectory.Add(102, "Mary");
            employeeDirectory.Add(103, "Steve");

            // Access by key
            Console.WriteLine(employeeDirectory[102]); // Mary

            // Iterate
            foreach (var kv in employeeDirectory)
            {
                Console.WriteLine($"ID: {kv.Key}, Name: {kv.Value}");
            }

            Dictionary<int, Student> studentDict = new Dictionary<int, Student>();

            studentDict.Add(1, new Student { Id = 1, Name = "Alice", Marks = 85 });
            studentDict[2] = new Student { Id = 2, Name = "Bob", Marks = 90 };

            // Retrieve by key
            if (studentDict.TryGetValue(2, out Student s))
            {
                Console.WriteLine($"Found: {s}");
            }
            Student ss = studentDict[1];

            // Iterate
            foreach (var kv in studentDict)
            {
                Console.WriteLine($"Key: {kv.Key}, Value: {kv.Value}");
            }

            // Remove
            studentDict.Remove(1);
        }
    }

}
