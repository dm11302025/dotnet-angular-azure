using HandsOnAPIUsingEFDemo_1.Entities;

namespace HandsOnAPIUsingEFDemo_1.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll(); //Get All Employees
        Employee GetById(int id); //Get Employee By Id
        void Update(int id,Employee employee); //Update Employee
        void Delete(int id); //Delete Employee
        void Add(Employee employee); //Add Employee
    }
}
