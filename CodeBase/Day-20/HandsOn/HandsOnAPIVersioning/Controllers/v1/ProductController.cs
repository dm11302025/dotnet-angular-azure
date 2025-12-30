using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIVersioning.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new[] { "Product v1 - A", "Product v1 - B" });
    }
}
