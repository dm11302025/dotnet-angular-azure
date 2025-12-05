namespace HandsOnAPIUsingEFDemo_1.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string ?Name { get; set; } //nullable reference type
        public double Salary { get; set; }
    }
}
