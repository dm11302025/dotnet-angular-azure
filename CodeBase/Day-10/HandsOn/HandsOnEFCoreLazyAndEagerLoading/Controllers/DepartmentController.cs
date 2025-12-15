using HandsOnEFCoreLazyAndEagerLoading.Data;
using HandsOnEFCoreLazyAndEagerLoading.DTOs;
using HandsOnEFCoreLazyAndEagerLoading.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandsOnEFCoreLazyAndEagerLoading.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // Get all departments with employees (Eager Loading)
        [HttpGet("eager")]
        public async Task<IActionResult> GetDepartmentsEager()
        {
            var data = await _context.Departments
                                     .Include(d => d.Employees)
                                     .ToListAsync();
            //var data = await _context.Departments
            //                        .ThenInclude(d => d.Employees)
            //                        .ToListAsync();
            return Ok(data);
    //        var departments = await _context.Departments
    //.Include(d => d.Employees)
    //.Select(d => new DepartmentDto
    //{
    //    DepartmentId = d.DepartmentId,
    //    Name = d.Name,
    //    Employees = d.Employees.Select(e => new EmployeeDto
    //    {
    //        EmployeeId = e.EmployeeId,
    //        FullName = e.FullName
    //    }).ToList()
    //})
    //.ToListAsync();

    //        return Ok(departments);
           
        }

        // Lazy loading version
        [HttpGet("lazy")]
        public async Task<IActionResult> GetDepartmentsLazy()
        {
            //var data = await _context.Departments.ToListAsync();

            //// Employees will load only when accessed here
            ////foreach (var d in data)
            ////{
            ////    var empCount = d.Employees.Count;
            ////}

            //return Ok(data);
            var department = await _context.Departments
.FirstAsync(d => d.DepartmentId == 1);
            // Employees not loaded yet
            var employees = department.Employees; // Lazy load happens here
            return Ok(department);
        }

        // Create a new Department
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok(department);
        }
        [HttpGet("explicit/{id}")]
        public async Task<IActionResult> GetDepartmentExplicit(int id)
        {
            // Load only the department
            var department = await _context.Departments
                                           .FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (department == null)
                return NotFound();

            // Explicitly load Employees
            await _context.Entry(department)
                          .Collection(d => d.Employees)
                          .LoadAsync();

            return Ok(department);
        }
    }
}
