namespace HandsOnEFCoreLazyAndEagerLoading.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }

        // Foreign Key
       
        public int DepartmentId { get; set; }

        // Navigation Property
        public  Department Department { get; set; }
    }
}
