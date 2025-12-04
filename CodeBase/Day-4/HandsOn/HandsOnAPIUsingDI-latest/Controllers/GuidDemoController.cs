using HandsOnAPIUsingDI_latest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingDI_latest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuidDemoController : ControllerBase
    {
        private readonly TransientGuidService _transient;
        private readonly ScopedGuidService _scoped;
        private readonly SingletonGuidService _singleton;

        public GuidDemoController(
            TransientGuidService transient,
            ScopedGuidService scoped,
            SingletonGuidService singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Transient = _transient.GetGuid(),
                Scoped = _scoped.GetGuid(),
                Singleton = _singleton.GetGuid()
            });
        }
    }

}
