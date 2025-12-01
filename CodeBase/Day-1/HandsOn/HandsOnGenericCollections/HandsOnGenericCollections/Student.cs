using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Marks { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Marks: {Marks}";
        }
    }

}
