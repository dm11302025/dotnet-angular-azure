using HandsOnAPIUsingSeperationOfConcerns.DTOs;
using HandsOnAPIUsingSeperationOfConcerns.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingSeperationOfConcerns.Controllers
{
    //7. Controller (API Endpoint) — Handles HTTP Only
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(ProductDto dto)
        {
            _service.CreateProduct(dto);
            return Ok("Product created");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.RemoveProduct(id);
            return Ok("Product deleted");
        }
    }
}
