using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIVersioning.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new[] { "Product v2 - A", "Product v2 - B", "Product v2 - C" });
    }
}
