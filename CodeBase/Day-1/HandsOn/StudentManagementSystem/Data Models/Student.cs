using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data_Models
{
    /// <summary>
    /// Represents a student in the system
    /// Demonstrates: Complex data types, nullable reference types
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }  // Nullable reference type
        public DateTime DateOfBirth { get; set; }
        public StudentStatus Status { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public Address? Address { get; set; }  // Nullable reference type

        // Computed properties
        public string FullName => $"{FirstName} {LastName}";
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public double? GPA => CalculateGPA();  // Nullable value type

        private double? CalculateGPA()
        {
            if (Grades == null || !Grades.Any()) return null;

            var validGrades = Grades.Where(g => g.Score.HasValue).ToList();
            return validGrades.Any() ? validGrades.Average(g => g.Score!.Value) : null;
        }
    }
}
