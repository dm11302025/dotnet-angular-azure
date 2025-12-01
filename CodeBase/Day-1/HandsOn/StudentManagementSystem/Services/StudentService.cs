using StudentManagementSystem.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagementSystem.Services
{
    /// <summary>
    /// Main service class for student management
    /// Demonstrates: Lists, operators, control statements, null handling
    /// </summary>
    public class StudentService
    {
        private List<Student> _students;
        private int _nextId;

        public StudentService()
        {
            _students = new List<Student>();
            _nextId = 1;
            InitializeSampleData();
        }

        /// <summary>
        /// Adds a new student - demonstrates null checking and validation
        /// </summary>
        public bool AddStudent(Student student)
        {
            // Null reference validation
            if (student == null)
            {
                Console.WriteLine("Error: Student cannot be null");
                return false;
            }

            // String validation using operators
            if (string.IsNullOrWhiteSpace(student.FirstName) ||
                string.IsNullOrWhiteSpace(student.LastName))
            {
                Console.WriteLine("Error: First name and last name are required");
                return false;
            }

            // Age validation using comparison operators
            if (student.Age < 16 || student.Age > 100)
            {
                Console.WriteLine("Error: Student age must be between 16 and 100");
                return false;
            }

            // Check for duplicate email using null-conditional operator
            if (!string.IsNullOrEmpty(student.Email) &&
                _students.Any(s => s.Email?.Equals(student.Email, StringComparison.OrdinalIgnoreCase) == true))
            {
                Console.WriteLine("Error: Email already exists");
                return false;
            }

            student.Id = _nextId++;
            _students.Add(student);
            Console.WriteLine($"Student {student.FullName} added successfully with ID: {student.Id}");
            return true;
        }

        /// <summary>
        /// Searches students - demonstrates various operators and control statements
        /// </summary>
        public List<Student> SearchStudents(string? searchTerm = null, StudentStatus? status = null)
        {
            var results = _students.AsEnumerable();

            // Use null-conditional operator and string methods
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                results = results.Where(s =>
                    s.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    (s.Email?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true));
            }

            // Use null-coalescing and comparison operators
            if (status.HasValue)
            {
                results = results.Where(s => s.Status == status.Value);
            }

            return results.ToList();
        }

        /// <summary>
        /// Generates student statistics - demonstrates arrays, loops, and mathematical operations
        /// </summary>
        public StudentStatistics GenerateStatistics()
        {
            var stats = new StudentStatistics();

            // Simple data types for counters
            int totalStudents = _students.Count;
            int activeStudents = 0, graduatedStudents = 0, suspendedStudents = 0;
            double totalGPA = 0;
            int studentsWithGPA = 0;

            // Array to track grade distribution
            int[] gradeDistribution = new int[6]; // A, B, C, D, F, NotGraded

            // Use foreach loop for iteration
            foreach (var student in _students)
            {
                // Switch statement for status counting
                switch (student.Status)
                {
                    case StudentStatus.Active:
                        activeStudents++;
                        break;
                    case StudentStatus.Graduated:
                        graduatedStudents++;
                        break;
                    case StudentStatus.Suspended:
                        suspendedStudents++;
                        break;
                }

                // Null checking and mathematical operations
                if (student.GPA.HasValue)
                {
                    totalGPA += student.GPA.Value;
                    studentsWithGPA++;
                }

                // Analyze grade distribution using for loop
                for (int i = 0; i < student.Grades.Count; i++)
                {
                    var gradeLevel = student.Grades[i].GetGradeLevel();
                    gradeDistribution[(int)gradeLevel]++;
                }
            }

            // Use ternary operator for conditional assignment
            stats.TotalStudents = totalStudents;
            stats.ActiveStudents = activeStudents;
            stats.GraduatedStudents = graduatedStudents;
            stats.SuspendedStudents = suspendedStudents;
            stats.AverageGPA = studentsWithGPA > 0 ? totalGPA / studentsWithGPA : 0;
            stats.GradeDistribution = gradeDistribution;

            return stats;
        }

        /// <summary>
        /// Bulk grade update - demonstrates arrays and batch operations
        /// </summary>
        public void BulkGradeUpdate(int[] studentIds, string subject, double[] scores)
        {
            // Validation using arrays and comparison operators
            if (studentIds == null || scores == null)
            {
                Console.WriteLine("Error: Student IDs and scores cannot be null");
                return;
            }

            if (studentIds.Length != scores.Length)
            {
                Console.WriteLine("Error: Number of student IDs must match number of scores");
                return;
            }

            // Use for loop with arrays
            for (int i = 0; i < studentIds.Length; i++)
            {
                var student = _students.FirstOrDefault(s => s.Id == studentIds[i]);

                // Null checking with continue statement
                if (student == null)
                {
                    Console.WriteLine($"Warning: Student with ID {studentIds[i]} not found");
                    continue;
                }

                // Validate score using logical operators
                if (scores[i] < 0 || scores[i] > 100)
                {
                    Console.WriteLine($"Warning: Invalid score {scores[i]} for student {student.FullName}");
                    continue;
                }

                // Add or update grade
                var existingGrade = student.Grades.FirstOrDefault(g => g.Subject == subject);
                if (existingGrade != null)
                {
                    existingGrade.Score = scores[i];
                    existingGrade.DateRecorded = DateTime.Now;
                }
                else
                {
                    student.Grades.Add(new Grade
                    {
                        Id = student.Grades.Count + 1,
                        Subject = subject,
                        Score = scores[i],
                        DateRecorded = DateTime.Now
                    });
                }

                Console.WriteLine($"Updated {subject} grade for {student.FullName}: {scores[i]}");
            }
        }

        /// <summary>
        /// Advanced search with multiple criteria
        /// </summary>
        public List<Student> AdvancedSearch(SearchCriteria criteria)
        {
            var query = _students.AsEnumerable();

            // Multiple null checks and logical operators
            if (criteria.MinAge.HasValue)
                query = query.Where(s => s.Age >= criteria.MinAge.Value);

            if (criteria.MaxAge.HasValue)
                query = query.Where(s => s.Age <= criteria.MaxAge.Value);

            if (criteria.MinGPA.HasValue)
                query = query.Where(s => s.GPA.HasValue && s.GPA >= criteria.MinGPA.Value);

            if (criteria.MaxGPA.HasValue)
                query = query.Where(s => s.GPA.HasValue && s.GPA <= criteria.MaxGPA.Value);

            if (criteria.Statuses != null && criteria.Statuses.Any())
                query = query.Where(s => criteria.Statuses.Contains(s.Status));

            if (!string.IsNullOrEmpty(criteria.City))
                query = query.Where(s => s.Address?.City.Equals(criteria.City, StringComparison.OrdinalIgnoreCase) == true);

            return query.ToList();
        }

        private void InitializeSampleData()
        {
            var sampleStudents = new Student[]
            {
                new Student
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@email.com",
                    DateOfBirth = new DateTime(2000, 5, 15),
                    Status = StudentStatus.Active,
                    Address = new Address("123 Main St", "Boston", "MA", "02101"),
                    Grades = new List<Grade>
                    {
                        new Grade { Id = 1, Subject = "Mathematics", Score = 95.5, DateRecorded = DateTime.Now.AddDays(-30) },
                        new Grade { Id = 2, Subject = "English", Score = 88.0, DateRecorded = DateTime.Now.AddDays(-25) },
                        new Grade { Id = 3, Subject = "Science", Score = 92.3, DateRecorded = DateTime.Now.AddDays(-20) }
                    }
                },
                new Student
                {
                    FirstName = "Emma",
                    LastName = "Johnson",
                    Email = "emma.johnson@email.com",
                    DateOfBirth = new DateTime(1999, 8, 22),
                    Status = StudentStatus.Active,
                    Address = new Address("456 Oak Ave", "Cambridge", "MA", "02138"),
                    Grades = new List<Grade>
                    {
                        new Grade { Id = 1, Subject = "Mathematics", Score = 78.5, DateRecorded = DateTime.Now.AddDays(-28) },
                        new Grade { Id = 2, Subject = "English", Score = 85.0, DateRecorded = DateTime.Now.AddDays(-23) },
                        new Grade { Id = 3, Subject = "Science", Score = null, DateRecorded = DateTime.Now.AddDays(-18) } // Not graded yet
                    }
                },
                new Student
                {
                    FirstName = "Michael",
                    LastName = "Brown",
                    Email = null, // No email provided
                    DateOfBirth = new DateTime(1998, 12, 3),
                    Status = StudentStatus.Graduated,
                    Address = null, // No address provided
                    Grades = new List<Grade>
                    {
                        new Grade { Id = 1, Subject = "Mathematics", Score = 94.0, DateRecorded = DateTime.Now.AddDays(-100) },
                        new Grade { Id = 2, Subject = "English", Score = 91.5, DateRecorded = DateTime.Now.AddDays(-95) },
                        new Grade { Id = 3, Subject = "Science", Score = 89.8, DateRecorded = DateTime.Now.AddDays(-90) }
                    }
                }
            };

            // Use foreach to add sample data
            foreach (var student in sampleStudents)
            {
                student.Id = _nextId++;
                _students.Add(student);
            }
        }

        public List<Student> GetAllStudents() => new List<Student>(_students);

        public Student? GetStudentById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public bool DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student == null) return false;

            return _students.Remove(student);
        }
    }

}
