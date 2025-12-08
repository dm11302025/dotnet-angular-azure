using HandsOnAPIUsingEFDemo_1.DTOs;
using HandsOnAPIUsingEFDemo_1.Entities;
using HandsOnAPIUsingEFDemo_1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingEFDemo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //Loose Coupling
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        //define endpoints
        [HttpPost("add")]
        public IActionResult AddEmployee(EmployeeDto employeeDto)
        {
            //convert dto to entity
            var employee = new Employee()
            {
                Id = 0,
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                Designation = employeeDto.Designation,
                JoinDate = System.DateTime.Now, //current date
            };
            employeeRepository.Add(employee);
            return Ok(employee); //return employee in json with status code 200
        }
        [HttpGet("getallemployees")]
        public IActionResult GetAll()
        {
            var employees=employeeRepository.GetAll();
            return Ok(employees);
        }
        [HttpGet("getemployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee=employeeRepository.GetById(id);
            if (employee == null)
                return NotFound("Invalid Employee Id");
            return Ok(employee);

        }
        [HttpPut("editemployee{id}")]
        public IActionResult EditEmployee(int id, Employee employee)
        {
            var emp= employeeRepository.GetById(id);
            if(emp!=null)
            employeeRepository.Update(id, employee);
            return Ok(employee);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            employeeRepository.Delete(id);
            return NoContent();
        }
    }
}
