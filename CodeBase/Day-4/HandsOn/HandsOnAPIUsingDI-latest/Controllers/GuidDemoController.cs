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
        private readonly TransientGuidService _transient1;
        private readonly ScopedGuidService _scoped;
        private readonly ScopedGuidService _scoped1;
        private readonly SingletonGuidService _singleton;
        private readonly SingletonGuidService _singleton1;

        public GuidDemoController(
            TransientGuidService transient,
            TransientGuidService transient1,
            ScopedGuidService scoped,
            ScopedGuidService scoped1,
            SingletonGuidService singleton,
            SingletonGuidService singleton1)
        {
            _transient = transient;
            _transient1 = transient1;
            _scoped = scoped;
            _scoped1 = scoped1;
            _singleton = singleton;
            _singleton1 = singleton1;
        }
        //public GuidDemoController()
        //{
        //    _singleton = new SingletonGuidService();
        //}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Transient = _transient.GetGuid(),
                Transient1 = _transient1.GetGuid(),
                Scoped = _scoped.GetGuid(),
                Scoped1= _scoped1.GetGuid(),
                Singleton = _singleton.GetGuid(),
                Signleton1= _singleton1.GetGuid(),
            });
        }
    }

}
