using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIVersioning.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetV1() => Ok("Version 1");

        [HttpGet, MapToApiVersion("2.0")]
        public IActionResult GetV2() => Ok("Version 2");
    }

}
