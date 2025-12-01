using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# FUNDAMENTALS EXAMPLES ===\n");

            // 1. SIMPLE AND COMPLEX DATA TYPES
            DataTypesExample();

            // 2. VARIABLES & ARRAYS
            VariablesAndArraysExample();

            // 3. OPERATORS
            OperatorsExample();

            // 4. CONTROL STATEMENTS
            ControlStatementsExample();

            // 5. LISTS
            ListsExample();

            // 6. NULL REFERENCE TYPES
            NullReferenceTypesExample();
        }

        // 1. SIMPLE AND COMPLEX DATA TYPES
        static void DataTypesExample()
        {
            Console.WriteLine("1. === SIMPLE AND COMPLEX DATA TYPES ===");

            // Simple Data Types (Value Types)
            int age = 25;                    // 32-bit integer
            double price = 99.99;            // 64-bit floating point
            float temperature = 36.5f;       // 32-bit floating point
            decimal salary = 75000.50m;      // 128-bit decimal for financial calculations
            char grade = 'A';                // Single character
            bool isActive = true;            // Boolean
            byte level = 255;                // 8-bit unsigned integer

            Console.WriteLine($"Age: {age}, Price: {price}, Grade: {grade}, Active: {isActive}");

            // Complex Data Types (Reference Types)
            string name = "John Doe";        // String (reference type)
            string[] colors = { "Red", "Blue", "Green" };  // Array (reference type)

            // Custom Class (Complex Type)
            Person person = new Person
            {
                Name = "Alice Smith",
                Age = 30,
                Email = "alice@example.com"
            };

            // Struct (Value Type but can be complex)
            Point coordinate = new Point(10, 20);

            Console.WriteLine($"Person: {person.Name}, {person.Age} years old");
            Console.WriteLine($"Coordinate: ({coordinate.X}, {coordinate.Y})");
            Console.WriteLine();
        }

        // 2. VARIABLES & ARRAYS
        static void VariablesAndArraysExample()
        {
            Console.WriteLine("2. === VARIABLES & ARRAYS ===");

            // Variable Declaration and Initialization
            int number;              // Declaration
            number = 42;            // Assignment
            int anotherNumber = 100; // Declaration + Assignment

            // Type inference with var
            var message = "Hello World";  // Compiler infers string
            var count = 10;              // Compiler infers int

            Console.WriteLine($"Number: {number}, Message: {message}");

            // Single-dimensional Arrays
            int[] numbers = new int[5];          // Array of 5 integers (initialized to 0)
            string[] names = { "Alice", "Bob", "Charlie" };  // Array literal

            // Initialize array with values
            int[] scores = new int[] { 85, 92, 78, 96, 88 };

            // Access array elements
            numbers[0] = 10;
            numbers[1] = 20;
            Console.WriteLine($"First number: {numbers[0]}, First name: {names[0]}");

            // Multi-dimensional Arrays
            int[,] matrix = new int[3, 3]    // 2D array (3x3)
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            // Jagged Arrays (Arrays of Arrays)
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3, 4 };
            jaggedArray[1] = new int[] { 5, 6 };
            jaggedArray[2] = new int[] { 7, 8, 9 };

            Console.WriteLine($"Matrix[1,1]: {matrix[1, 1]}"); //5
            Console.WriteLine($"Jagged[0][2]: {jaggedArray[0][2]}"); //3
            Console.WriteLine();
        }

        // 3. OPERATORS
        static void OperatorsExample()
        {
            Console.WriteLine("3. === OPERATORS ===");

            int a = 10, b = 3;

            // Arithmetic Operators
            Console.WriteLine("Arithmetic Operators:");
            Console.WriteLine($"a + b = {a + b}");    // Addition: 13
            Console.WriteLine($"a - b = {a - b}");    // Subtraction: 7
            Console.WriteLine($"a * b = {a * b}");    // Multiplication: 30
            Console.WriteLine($"a / b = {a / b}");    // Division: 3 (integer division)
            Console.WriteLine($"a % b = {a % b}");    // Modulus: 1

            // Comparison Operators
            Console.WriteLine("\nComparison Operators:");
            Console.WriteLine($"a == b: {a == b}");   // Equal to: False
            Console.WriteLine($"a != b: {a != b}");   // Not equal to: True
            Console.WriteLine($"a > b: {a > b}");     // Greater than: True
            Console.WriteLine($"a < b: {a < b}");     // Less than: False
            Console.WriteLine($"a >= b: {a >= b}");   // Greater than or equal: True
            Console.WriteLine($"a <= b: {a <= b}");   // Less than or equal: False

            // Logical Operators
            bool x = true, y = false;
            Console.WriteLine("\nLogical Operators:");
            Console.WriteLine($"x && y: {x && y}");   // Logical AND: False
            Console.WriteLine($"x || y: {x || y}");   // Logical OR: True
            Console.WriteLine($"!x: {!x}");          // Logical NOT: False

            // Assignment Operators
            Console.WriteLine("\nAssignment Operators:");
            int c = 5;
            c += 3;  // c = c + 3
            Console.WriteLine($"c += 3: {c}");        // 8
            c -= 2;  // c = c - 2
            Console.WriteLine($"c -= 2: {c}");        // 6
            c *= 2;  // c = c * 2
            Console.WriteLine($"c *= 2: {c}");        // 12

            // Increment/Decrement Operators
            int d = 5;
            Console.WriteLine($"d++: {d++}");         // Post-increment: 5 (then d becomes 6)
            Console.WriteLine($"++d: {++d}");         // Pre-increment: 7
            Console.WriteLine($"d--: {d--}");         // Post-decrement: 7 (then d becomes 6)
            Console.WriteLine($"--d: {--d}");         // Pre-decrement: 5

            // Ternary Operator
            string result = (a > b) ? "a is greater" : "b is greater";
            Console.WriteLine($"Ternary: {result}");

            // Null-coalescing Operator
            string nullString = null;
            string defaultValue = nullString ?? "Default Value";
            Console.WriteLine($"Null-coalescing: {defaultValue}");
            Console.WriteLine();
        }

        // 4. CONTROL STATEMENTS
        static void ControlStatementsExample()
        {
            Console.WriteLine("4. === CONTROL STATEMENTS ===");

            // If-else statements
            int score = 85;
            Console.WriteLine("If-else example:");
            if (score >= 90)
                Console.WriteLine("Grade: A");
            else if (score >= 80)
                Console.WriteLine("Grade: B");
            else if (score >= 70)
                Console.WriteLine("Grade: C");
            else
                Console.WriteLine("Grade: F");

            // Switch statement
            char grade = 'B';
            Console.WriteLine("\nSwitch example:");
            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent!");
                    break;
                case 'B':
                    Console.WriteLine("Good job!");
                    break;
                case 'C':
                    Console.WriteLine("Average");
                    break;
                default:
                    Console.WriteLine("Keep trying!");
                    break;
            }

            // Switch expression (C# 8.0+)
            string gradeMessage = grade switch
            {
                'A' => "Outstanding!",
                'B' => "Well done!",
                'C' => "Satisfactory",
                _ => "Needs improvement"
            };
            Console.WriteLine($"Switch expression: {gradeMessage}");

            // For loop
            Console.WriteLine("\nFor loop example:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Iteration {i}");
            }

            // While loop
            Console.WriteLine("\nWhile loop example:");
            int counter = 1;
            while (counter <= 3)
            {
                Console.WriteLine($"Counter: {counter}");
                counter++;
            }

            // Do-while loop
            Console.WriteLine("\nDo-while loop example:");
            int num = 1;
            do
            {
                Console.WriteLine($"Number: {num}");
                num++;
            } while (num <= 2);

            // Foreach loop
            Console.WriteLine("\nForeach loop example:");
            string[] fruits = { "Apple", "Banana", "Orange" };
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"Fruit: {fruit}");
            }

            // Break and Continue
            Console.WriteLine("\nBreak and Continue example:");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 3) continue;  // Skip iteration when i = 3
                if (i == 7) break;     // Exit loop when i = 7
                Console.WriteLine($"Value: {i}");
            }
            Console.WriteLine();
        }

        // 5. LISTS
        static void ListsExample()
        {
            Console.WriteLine("5. === LISTS ===");

            // Creating and initializing lists
            List<int> numbers = new List<int>();           // Empty list
            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };  // List with initial values

            // Adding elements
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.AddRange(new int[] { 40, 50 });

            Console.WriteLine("List operations:");
            Console.WriteLine($"Numbers count: {numbers.Count}");
            Console.WriteLine($"First number: {numbers[0]}");
            Console.WriteLine($"Contains 20: {numbers.Contains(20)}");

            // List methods
            names.Insert(1, "David");          // Insert at specific index
            names.Remove("Bob");               // Remove specific item
            names.RemoveAt(0);                 // Remove at specific index

            Console.WriteLine($"Names after modifications: {string.Join(", ", names)}");

            // Finding elements
            List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
            var oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();
            var result = numbers.Where(n => n > 10); //return IEnumarable<int> type
            int firstLarge = numbers.FirstOrDefault(n => n > 25);

            Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");
            Console.WriteLine($"First number > 25: {firstLarge}");

            // Sorting and other operations
            numbers.Sort();
            Console.WriteLine($"Sorted numbers: {string.Join(", ", numbers)}");

            numbers.Reverse();
            Console.WriteLine($"Reversed numbers: {string.Join(", ", numbers)}");

            // List of custom objects
            List<Person> people = new List<Person>
            {
                new Person { Name = "John", Age = 25, Email = "john@email.com" },
                new Person { Name = "Jane", Age = 30, Email = "jane@email.com" },
                new Person { Name = "Bob", Age = 35, Email = "bob@email.com" }
            };

            var adults = people.Where(p => p.Age >= 30).ToList();
            Console.WriteLine($"Adults: {string.Join(", ", adults.Select(p => p.Name))}");
            Console.WriteLine();
        }

        // 6. NULL REFERENCE TYPES
        static void NullReferenceTypesExample()
        {
            Console.WriteLine("6. === NULL REFERENCE TYPES ===");

            // Traditional nullable reference types (before C# 8)
            string? nullableString = null;    // Can be null
            string regularString = "Hello";   // Should not be null (but can be)

            // Checking for null
            if (nullableString != null)
            {
                Console.WriteLine($"Length: {nullableString.Length}");
            }
            else
            {
                Console.WriteLine("String is null");
            }

            // Null-conditional operators
            Console.WriteLine($"Null-conditional length: {nullableString?.Length}");
            Console.WriteLine($"Null-conditional with default: {nullableString?.Length ?? 0}");

            // Null-coalescing assignment (C# 8.0+)
            nullableString ??= "Default value";
            Console.WriteLine($"After null-coalescing assignment: {nullableString}");

            // Working with nullable value types
            int? nullableInt = null;
            int? anotherInt = 42;

            Console.WriteLine($"Nullable int has value: {nullableInt.HasValue}");
            Console.WriteLine($"Another int value: {anotherInt.Value}");

            // Safe access patterns
            Person? person = GetPersonOrNull();
            string email = person?.Email ?? "No email provided";
            Console.WriteLine($"Email: {email}");

            // Null forgiving operator (!)
            Person definitelyNotNull = GetPersonOrNull()!;  // Tell compiler it's not null
            Console.WriteLine($"Person name: {definitelyNotNull.Name}");

            // Pattern matching with null
            object? someObject = "Hello World";
            string result = someObject switch
            {
                string s => $"String: {s}",
                int i => $"Integer: {i}",
                null => "Object is null",
                _ => "Unknown type"
            };
            Console.WriteLine($"Pattern matching result: {result}");

            // Defensive programming with null checks
            ProcessData(null);
            ProcessData("Valid data");

            Console.WriteLine();
        }

        // Helper methods
        static Person? GetPersonOrNull()
        {
            // Simulate getting a person that might be null
            return new Person { Name = "Sample Person", Age = 25, Email = "sample@email.com" };
        }

        static void ProcessData(string? data)
        {
            if (string.IsNullOrEmpty(data))
            {
                Console.WriteLine("ProcessData: No data provided or empty");
                return;
            }

            Console.WriteLine($"ProcessData: Processing '{data}'");
        }
    }

    // Custom classes and structs
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}