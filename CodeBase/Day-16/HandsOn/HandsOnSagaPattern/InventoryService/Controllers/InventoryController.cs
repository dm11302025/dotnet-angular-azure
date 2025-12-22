using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        [HttpPost("reserve")]
        public IActionResult Reserve(InventoryRequest request)
        {
            if (request.Quantity > 10)
                return BadRequest("Insufficient stock");

            return Ok();
        }

        [HttpPost("release")]
        public IActionResult Release(InventoryRequest request)
        {
            return Ok();
        }
    }

}
