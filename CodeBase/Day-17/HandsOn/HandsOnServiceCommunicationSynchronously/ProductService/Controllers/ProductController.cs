using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        List<int> products = new List<int>() { 12, 23, 34, 35, 67, 78, 89 };
        [HttpGet("{id}/availability")]
        public IActionResult CheckAvailability(int id)
        {
            if (products.Contains(id))
                return Ok(new { ProductId = id, Available = true });
            else
                return Ok(new { ProductId = id, Available = false });
        }
    }

}
