using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data_Models
{
    public class SearchCriteria
    {
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public double? MinGPA { get; set; }
        public double? MaxGPA { get; set; }
        public List<StudentStatus>? Statuses { get; set; }
        public string? City { get; set; }
    }
}
