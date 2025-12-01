using HandsOnGenericCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_Stack
{
    /*
     What it is: A LIFO (Last In, First Out) collection.

When to use: When you need reverse order processing (undo operations, parsing expressions).
     */
    class Program
    {
        static void Main()
        {
            Stack<string> history = new Stack<string>();
            history.Push("Page1");
            history.Push("Page2");
            history.Push("Page3");

            Console.WriteLine(history.Pop());  // Page3 (last in, first out)
            Console.WriteLine(history.Peek()); // Page2 (top element, not removed)

            Stack<Student> studentStack = new Stack<Student>();

            studentStack.Push(new Student { Id = 1, Name = "Alice", Marks = 85 });
            studentStack.Push(new Student { Id = 2, Name = "Bob", Marks = 90 });

            Console.WriteLine($"Popped: {studentStack.Pop()}"); // Bob
            Console.WriteLine($"Peek: {studentStack.Peek()}");  // Alice
        }
    }

}
