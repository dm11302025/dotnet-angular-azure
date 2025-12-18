using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MathLibrary;
namespace MathAPI.Controllers
{
    class Demo
    {
        public int Sum { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpPost("add/{a}/{b}")]
        public IActionResult Add(int a, int b)
        {
            Demo d = new Demo() { Sum = 10 };
            int result = Calculate.Add(a, b);
            return Ok(result);
        }
        [HttpPost("square/{number}")]
        public IActionResult Square(int number)
        {
            Calculate calculate = new Calculate();
            int result = calculate.Square(number);
            return Ok(new { Result = result });
        }
    }
}
