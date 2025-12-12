namespace HandsOnEFCoreLazyAndEagerLoading.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        // ONE department has MANY employees
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
