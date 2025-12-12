namespace HandsOnEFCoreLazyAndEagerLoading.DTOs
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
