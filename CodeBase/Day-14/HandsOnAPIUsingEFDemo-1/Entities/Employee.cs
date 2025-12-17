namespace HandsOnAPIUsingEFDemo_1.Entities
{
    public class Employee
    {
        public int Id { get; set; } //set as Primary key default
        public string ?Name { get; set; } //nullable reference type
        public double Salary { get; set; }
        public string Designation { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
