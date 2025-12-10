using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingExceptionHandling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            // Force an exception
            throw new Exception("Something broke!");
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id) { throw new NotFoundException("Product Not found"); }

    }

}
