using StudentManagementSystem.Data_Models;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace StudentManagementSystem
{
    class Program
    {
        private static StudentService _studentService = new StudentService();

        static void Main(string[] args)
        {
            Console.WriteLine("=== STUDENT MANAGEMENT SYSTEM ===");
            Console.WriteLine("Complete Case Study Application\n");

            bool running = true;

            // Main application loop - demonstrates while loop and control statements
            while (running)
            {
                DisplayMenu();
                var choice = Console.ReadLine()?.Trim();

                // Switch statement for menu handling
                switch (choice)
                {
                    case "1":
                        AddNewStudent();
                        break;
                    case "2":
                        DisplayAllStudents();
                        break;
                    case "3":
                        SearchStudentsDemo();
                        break;
                    case "4":
                        AddGradesToStudent();
                        break;
                    case "5":
                        BulkGradeUpdateDemo();
                        break;
                    case "6":
                        DisplayStatistics();
                        break;
                    case "7":
                        AdvancedSearchDemo();
                        break;
                    case "8":
                        DataTypesDemo();
                        break;
                    case "9":
                        OperatorsDemo();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Thank you for using Student Management System!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("=== STUDENT MANAGEMENT SYSTEM ===");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Students");
            Console.WriteLine("4. Add Grades to Student");
            Console.WriteLine("5. Bulk Grade Update");
            Console.WriteLine("6. Display Statistics");
            Console.WriteLine("7. Advanced Search Demo");
            Console.WriteLine("8. Data Types Demo");
            Console.WriteLine("9. Operators Demo");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");
        }

        static void AddNewStudent()
        {
            Console.WriteLine("\n=== ADD NEW STUDENT ===");

            try
            {
                Console.Write("First Name: ");
                string firstName = Console.ReadLine() ?? string.Empty;

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine() ?? string.Empty;

                Console.Write("Email (optional): ");
                string? email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email)) email = null;

                Console.Write("Date of Birth (yyyy-mm-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
                {
                    Console.WriteLine("Invalid date format!");
                    return;
                }

                Console.WriteLine("Status: 1-Active, 2-Inactive, 3-Graduated, 4-Suspended, 5-Transferred");
                Console.Write("Select status: ");
                if (!int.TryParse(Console.ReadLine(), out int statusInt) ||
                    !Enum.IsDefined(typeof(StudentStatus), statusInt))
                {
                    Console.WriteLine("Invalid status!");
                    return;
                }

                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = dob,
                    Status = (StudentStatus)statusInt
                };

                _studentService.AddStudent(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }

        static void DisplayAllStudents()
        {
            Console.WriteLine("\n=== ALL STUDENTS ===");
            var students = _studentService.GetAllStudents();

            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                DisplayStudentInfo(student);
                Console.WriteLine(new string('-', 50));
            }
        }

        static void SearchStudentsDemo()
        {
            Console.WriteLine("\n=== SEARCH STUDENTS ===");
            Console.Write("Enter search term (name or email): ");
            string? searchTerm = Console.ReadLine();

            Console.WriteLine("Status filter (optional): 1-Active, 2-Inactive, 3-Graduated, 4-Suspended, 5-Transferred");
            Console.Write("Select status (or press Enter to skip): ");
            string statusInput = Console.ReadLine() ?? string.Empty;

            StudentStatus? status = null;
            if (!string.IsNullOrWhiteSpace(statusInput) && int.TryParse(statusInput, out int statusInt))
            {
                status = (StudentStatus)statusInt;
            }

            var results = _studentService.SearchStudents(searchTerm, status);

            Console.WriteLine($"\nFound {results.Count} student(s):");
            foreach (var student in results)
            {
                DisplayStudentInfo(student);
                Console.WriteLine(new string('-', 30));
            }
        }

        static void AddGradesToStudent()
        {
            Console.WriteLine("\n=== ADD GRADES ===");
            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid student ID!");
                return;
            }

            var student = _studentService.GetStudentById(studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Console.Write("Subject: ");
            string subject = Console.ReadLine() ?? string.Empty;

            Console.Write("Score (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double score))
            {
                Console.WriteLine("Invalid score!");
                return;
            }

            var grade = new Grade
            {
                Id = student.Grades.Count + 1,
                Subject = subject,
                Score = score,
                DateRecorded = DateTime.Now
            };

            student.Grades.Add(grade);
            Console.WriteLine($"Grade added successfully! New GPA: {student.GPA:F2}");
        }

        static void BulkGradeUpdateDemo()
        {
            Console.WriteLine("\n=== BULK GRADE UPDATE DEMO ===");

            // Demonstrate arrays and bulk operations
            int[] studentIds = { 1, 2, 3 };
            double[] mathScores = { 95.0, 87.5, 91.2 };

            Console.WriteLine("Updating Math scores for students 1, 2, and 3...");
            _studentService.BulkGradeUpdate(studentIds, "Mathematics", mathScores);

            Console.WriteLine("\nUpdated students:");
            foreach (int id in studentIds)
            {
                var student = _studentService.GetStudentById(id);
                if (student != null)
                {
                    Console.WriteLine($"{student.FullName} - New GPA: {student.GPA:F2}");
                }
            }
        }

        static void DisplayStatistics()
        {
            Console.WriteLine("\n=== STUDENT STATISTICS ===");
            var stats = _studentService.GenerateStatistics();

            Console.WriteLine($"Total Students: {stats.TotalStudents}");
            Console.WriteLine($"Active Students: {stats.ActiveStudents}");
            Console.WriteLine($"Graduated Students: {stats.GraduatedStudents}");
            Console.WriteLine($"Suspended Students: {stats.SuspendedStudents}");
            Console.WriteLine($"Average GPA: {stats.AverageGPA:F2}");

            Console.WriteLine("\nGrade Distribution:");
            string[] gradeLabels = { "A", "B", "C", "D", "F", "Not Graded" };
            for (int i = 0; i < stats.GradeDistribution.Length; i++)
            {
                Console.WriteLine($"{gradeLabels[i]}: {stats.GradeDistribution[i]} grades");
            }
        }

        static void AdvancedSearchDemo()
        {
            Console.WriteLine("\n=== ADVANCED SEARCH DEMO ===");

            var criteria = new SearchCriteria
            {
                MinAge = 20,
                MaxAge = 30,
                MinGPA = 80.0,
                Statuses = new List<StudentStatus> { StudentStatus.Active, StudentStatus.Graduated }
            };

            Console.WriteLine("Searching for students aged 20-30 with GPA >= 80 who are Active or Graduated:");

            var results = _studentService.AdvancedSearch(criteria);
            Console.WriteLine($"\nFound {results.Count} student(s):");

            foreach (var student in results)
            {
                Console.WriteLine($"- {student.FullName}, Age: {student.Age}, GPA: {student.GPA:F2}, Status: {student.Status}");
            }
        }

        static void DataTypesDemo()
        {
            Console.WriteLine("\n=== DATA TYPES DEMONSTRATION ===");

            // Simple data types
            int studentCount = 150;
            double averageGPA = 3.75;
            bool isAccredited = true;
            char gradeA = 'A';

            Console.WriteLine("Simple Data Types:");
            Console.WriteLine($"Student Count (int): {studentCount}");
            Console.WriteLine($"Average GPA (double): {averageGPA}");
            Console.WriteLine($"Is Accredited (bool): {isAccredited}");
            Console.WriteLine($"Top Grade (char): {gradeA}");

            // Complex data types
            string[] subjects = { "Math", "English", "Science", "History" };
            List<string> departments = new List<string> { "Engineering", "Arts", "Sciences" };

            Console.WriteLine("\nComplex Data Types:");
            Console.WriteLine($"Subjects (array): {string.Join(", ", subjects)}");
            Console.WriteLine($"Departments (list): {string.Join(", ", departments)}");

            // Nullable types
            int? optionalScore = null;
            double? gpa = 3.85;

            Console.WriteLine("\nNullable Types:");
            Console.WriteLine($"Optional Score: {optionalScore?.ToString() ?? "Not provided"}");
            Console.WriteLine($"GPA: {gpa?.ToString("F2") ?? "Not calculated"}");
        }

        static void OperatorsDemo()
        {
            Console.WriteLine("\n=== OPERATORS DEMONSTRATION ===");

            int score1 = 85, score2 = 92;

            // Arithmetic operators
            Console.WriteLine("Arithmetic Operators:");
            Console.WriteLine($"Average of {score1} and {score2}: {(score1 + score2) / 2.0}");
            Console.WriteLine($"Difference: {score2 - score1}");
            Console.WriteLine($"Score1 % 10: {score1 % 10}");

            // Comparison operators
            Console.WriteLine("\nComparison Operators:");
            Console.WriteLine($"{score1} > {score2}: {score1 > score2}");
            Console.WriteLine($"{score1} == {score2}: {score1 == score2}");
            Console.WriteLine($"{score1} != {score2}: {score1 != score2}");

            // Logical operators
            bool isPassing1 = score1 >= 70;
            bool isPassing2 = score2 >= 70;
            Console.WriteLine("\nLogical Operators:");
            Console.WriteLine($"Both passing: {isPassing1 && isPassing2}");
            Console.WriteLine($"At least one passing: {isPassing1 || isPassing2}");
            Console.WriteLine($"Score1 not passing: {!isPassing1}");

            // Null-coalescing operators
            string? optionalName = null;
            Console.WriteLine("\nNull-coalescing Operators:");
            Console.WriteLine($"Name: {optionalName ?? "No name provided"}");

            optionalName ??= "Default Student";
            Console.WriteLine($"After assignment: {optionalName}");
        }

        static void DisplayStudentInfo(Student student)
        {
            Console.WriteLine($"ID: {student.Id}");
            Console.WriteLine($"Name: {student.FullName}");
            Console.WriteLine($"Email: {student.Email ?? "Not provided"}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"Status: {student.Status}");
            Console.WriteLine($"Address: {student.Address?.ToString() ?? "Not provided"}");
            Console.WriteLine($"GPA: {student.GPA?.ToString("F2") ?? "Not calculated"}");

            if (student.Grades.Any())
            {
                Console.WriteLine("Grades:");
                foreach (var grade in student.Grades)
                {
                    string scoreText = grade.Score?.ToString("F1") ?? "Not graded";
                    Console.WriteLine($"  - {grade.Subject}: {scoreText} ({grade.GetGradeLevel()})");
                }
            }
        }
    }

}