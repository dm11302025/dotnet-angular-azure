using HandsOnGenericCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_List
{
    /*
     List<T>

What it is: A dynamic array that can grow/shrink as needed.

When to use: When you need an ordered collection that allows duplicates and fast access by index.
     */
    class Program
    {
        static void Main()
        {
            List<string> students = new List<string>();
            students.Add("Alice");
            students.Add("Bob");
            students.Add("Charlie");

            // Access by index
            Console.WriteLine(students[1]); // Bob

            // Iterate
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            List<Student> studentsList = new List<Student> //collection initializer
        {
            new Student { Id = 1, Name = "Alice", Marks = 85 },
            new Student { Id = 2, Name = "Bob", Marks = 90 }
        };

            studentsList.Add(new Student { Id = 3, Name = "Charlie", Marks = 70 });
            studentsList.Insert(1, new Student { Id = 4, Name = "David", Marks = 88 });

            Console.WriteLine("All Students:");
            studentsList.ForEach(s => Console.WriteLine(s));

            // Find first matching student
            var topper = studentsList.Find(s => s.Marks > 85);
            Console.WriteLine($"\nTopper Found: {topper}");

            // Remove a student
            studentsList.RemoveAll(s => s.Name == "Charlie");

            Console.WriteLine("\nAfter Removal:");
            students.ForEach(s => Console.WriteLine(s));
        }
    }

}
