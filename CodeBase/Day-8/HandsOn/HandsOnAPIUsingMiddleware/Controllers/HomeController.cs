using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("welcome")]
        public IActionResult Welcome()
        {
            return Ok("Welcome to Middleware Demo API!");
        }

        [HttpGet("data")]
        public IActionResult GetData()
        {
            return Ok(new { Id = 1, Name = "Middleware Example" });
        }
    }
}
