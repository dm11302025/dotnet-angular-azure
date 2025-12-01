using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data_Models
{
    public class StudentStatistics
    {
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int GraduatedStudents { get; set; }
        public int SuspendedStudents { get; set; }
        public double AverageGPA { get; set; }
        public int[] GradeDistribution { get; set; } = new int[6];
    }
}
