using System.Linq;
namespace HandsOnLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };
            ////1.Query syntax
            //var result=from i in numbers
            //           where i>20
            //           select i;
            //result = from i in numbers
            //         where i > 15 && i % 2 == 0
            //         select i;
            //result = from i in numbers
            //         where i > 5
            //         orderby i descending
            //         select i;
            //foreach(var i in result)
            //    Console.WriteLine(i);
            ////2. Method syntax
            //var result1 = numbers.Where(i => i > 20);
            //result1=numbers.Where(i=>i>20 && i%2==0);
            //result1 = numbers.Where(i => i > 5).OrderByDescending(i => i);
            var students = new List<Student>
{
    new Student { Id = 1, Name = "Amit",  Marks = 80, Gender = "Male" },
    new Student { Id = 2, Name = "Sana",  Marks = 95, Gender = "Female" },
    new Student { Id = 3, Name = "John",  Marks = 60, Gender = "Male" },
    new Student { Id = 4, Name = "Riya",  Marks = 72, Gender = "Female" },
    new Student { Id = 5, Name = "Alex",  Marks = 88, Gender = "Male" }
};

            var student = students.Where(s => s.Id == 3);
            foreach(Student s in student)
            {
                Console.WriteLine($"Id:{s.Id} Name:{s.Name} Marks:{s.Marks} Gender:{s.Gender}");
            }
            //Single() throw exception when sequence contains 0 or more records
            Student student1=students.Where(s=>s.Id == 4).Single();
            //SingleOrDefault() throw exception when sequence contains more records
            //returns default value when sequence contains no records
            student1 = students.Where(s => s.Id == 40).SingleOrDefault();
            if(student1 != null)
            Console.WriteLine($"Id:{student1.Id} Name:{student1.Name} Marks:{student1.Marks} Gender:{student1.Gender}");
            student1 = students.Where(s => s.Gender == "Male").FirstOrDefault();
            List<Student> maleStudents= students.Where(s => s.Gender == "Male").ToList();
            Student[] students2 = students.Where(s => s.Marks > 80).ToArray();
            int count= students.Where(s => s.Gender == "Male").Count();
        }
    }
}
