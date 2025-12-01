using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data_Models
{
    /// <summary>
    /// Enumerations - simple data types
    /// </summary>
    public enum StudentStatus
    {
        Active = 1,
        Inactive = 2,
        Graduated = 3,
        Suspended = 4,
        Transferred = 5
    }

    public enum GradeLevel
    {
        A, B, C, D, F, NotGraded
    }
}
