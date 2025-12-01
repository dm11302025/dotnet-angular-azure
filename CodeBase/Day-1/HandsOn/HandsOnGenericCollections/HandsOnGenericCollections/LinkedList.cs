using HandsOnGenericCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_LinkedList
{
    /*
     LinkedList<T>

What it is: A doubly linked list (each node points to next & previous).

When to use: When you need fast insertions/removals at beginning or middle, but not random access.
     */

    class Program
    {
        static void Main()
        {
            LinkedList<string> playlist = new LinkedList<string>();
            playlist.AddLast("Song1");
            playlist.AddLast("Song2");
            playlist.AddFirst("Intro Song");

            foreach (var song in playlist)
            {
                Console.WriteLine(song);
            }

            LinkedList<Student> studentList = new LinkedList<Student>();

            studentList.AddLast(new Student { Id = 1, Name = "Alice", Marks = 85 });
            studentList.AddLast(new Student { Id = 2, Name = "Bob", Marks = 90 });
            studentList.AddFirst(new Student { Id = 3, Name = "Charlie", Marks = 70 });

            Console.WriteLine("Linked List Students:");
            foreach (var s in studentList)
            {
                Console.WriteLine(s);
            }

            // Find & insert after
            var node = studentList.Find(new Student { Id = 1, Name = "Alice", Marks = 85 });
            // This will not work unless you provide custom equality
            // Instead, you’d iterate and find manually by Id
        }
    }

}
