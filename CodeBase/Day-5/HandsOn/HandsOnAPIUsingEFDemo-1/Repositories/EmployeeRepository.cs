using HandsOnAPIUsingEFDemo_1.DataProvider;
using HandsOnAPIUsingEFDemo_1.Entities;

namespace HandsOnAPIUsingEFDemo_1.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
          //Add new employee
          _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            //Delete Employee
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            //Get All Employees
            var employees = _context.Employees.ToList();
            return employees;
        }

        public Employee GetById(int id)
        {
           var employee=_context.Employees.Find(id);
            return employee;
        }

        public void Update(int id, Employee employee)
        {
            //Update Employee
            var emp= _context.Employees.Find(id);
            if (emp != null)
            {
                emp.Salary = employee.Salary;
                emp.Designation = employee.Designation;
                _context.Employees.Update(emp);
                _context.SaveChanges();
            }
          
        }
    }
}
