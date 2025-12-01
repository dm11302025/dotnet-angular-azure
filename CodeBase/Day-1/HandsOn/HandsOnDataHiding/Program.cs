namespace HandsOnDataHiding
{
    using System;

    public class Student
    {
        // Data Hiding: private fields cannot be accessed directly
        private string? name;
        private int age;

        // Encapsulation: public methods and properties to safely access private fields
        public string? Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                    age = value;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }

    class Program
    {
        static void Main()
        {
            Student student = new Student();

            // Using encapsulation to set private data safely
            student.Name = "Adrija";  // safe access via property
            student.Age = 6;

            // Direct access is not allowed (data hiding)
            // student.name = "Adrija";  ❌ Error
            // student.age = 6; ❌ Error

            student.DisplayInfo();
            /*
             Data Hiding

private string name and private int age are hidden from the outside world.

You cannot access them directly.

             */
        }
    }

}
