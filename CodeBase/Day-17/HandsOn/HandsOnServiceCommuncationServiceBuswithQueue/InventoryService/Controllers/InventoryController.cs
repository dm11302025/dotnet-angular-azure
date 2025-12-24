using InventoryService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepository _repository;

        public InventoryController(InventoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{productId}")]
        public IActionResult GetInventory(int productId)
        {
            var item = _repository.GetByProductId(productId);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}