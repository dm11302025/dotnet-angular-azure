using HandsOnGenericCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_SortedList
{
    /*
     SortedList<TKey, TValue>

  What it is: A key-value collection like Dictionary, but keeps items sorted by key.

  When to use: When you want a dictionary with automatic sorting by keys.
     */

    class Program
    {
        static void Main()
        {
            SortedList<int, string> marks = new SortedList<int, string>();
            marks.Add(90, "Alice");
            marks.Add(75, "Bob");
            marks.Add(82, "Charlie");

            // Automatically sorted by key
            foreach (var kv in marks)
            {
                Console.WriteLine($"Score: {kv.Key}, Student: {kv.Value}");
            }

            SortedList<int, Student> sortedStudents = new SortedList<int, Student>();

            sortedStudents.Add(103, new Student { Id = 103, Name = "Charlie", Marks = 70 });
            sortedStudents.Add(101, new Student { Id = 101, Name = "Alice", Marks = 85 });
            sortedStudents.Add(102, new Student { Id = 102, Name = "Bob", Marks = 90 });

            Console.WriteLine("Sorted by Key:");
            foreach (var kv in sortedStudents)
            {
                Console.WriteLine($"{kv.Key} => {kv.Value}");
            }
        }
    }

}
