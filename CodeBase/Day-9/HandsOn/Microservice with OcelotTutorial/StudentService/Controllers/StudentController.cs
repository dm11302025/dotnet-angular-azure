using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.Service;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository) =>
            (_studentRepository) = (studentRepository);


        [HttpGet,Route("GetStudents")]
        public IActionResult GetAll()
        {
            return Ok(_studentRepository.GetAll());
        }

        [HttpGet(),Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentRepository.Get(id);
            if(student is null) 
                return NotFound();

            return Ok(student);
        }
    }
}
