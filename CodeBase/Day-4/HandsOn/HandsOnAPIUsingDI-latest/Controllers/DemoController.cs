using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingDI_latest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly Car car;
        public DemoController(Car car)
        {
            this.car = car;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(car.Details());
        }

    }
}
