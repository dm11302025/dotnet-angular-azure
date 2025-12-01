using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data_Models
{
    /// <summary>
    /// Represents a grade for a subject
    /// Demonstrates: Value types, nullable types
    /// </summary>
    public class Grade
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public double? Score { get; set; }  // Nullable - might not be graded yet
        public DateTime DateRecorded { get; set; }
        public string? Comments { get; set; }

        public GradeLevel GetGradeLevel()
        {
            if (!Score.HasValue) return GradeLevel.NotGraded;

            return Score.Value switch
            {
                >= 90 => GradeLevel.A,
                >= 80 => GradeLevel.B,
                >= 70 => GradeLevel.C,
                >= 60 => GradeLevel.D,
                _ => GradeLevel.F
            };
        }
    }
}
