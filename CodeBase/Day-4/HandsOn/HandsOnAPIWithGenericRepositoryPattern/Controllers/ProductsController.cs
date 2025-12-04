using HandsOnAPIWithGenericRepositoryPattern.CustomRepositories;
using HandsOnAPIWithGenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIWithGenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repo.GetById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var created = _repo.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest("ID mismatch");
            var updated = _repo.Update(product);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _repo.Delete(id) ? NoContent() : NotFound();
        }

        // ---------- Custom Methods Below ----------

        [HttpGet("low-stock/{threshold}")]
        public IActionResult GetLowStock(int threshold)
        {
            return Ok(_repo.GetProductsWithLowStock(threshold));
        }

        [HttpGet("price-range")]
        public IActionResult GetPriceRange(decimal min, decimal max)
        {
            return Ok(_repo.GetProductsByPriceRange(min, max));
        }

        [HttpGet("search/{keyword}")]
        public IActionResult Search(string keyword)
        {
            return Ok(_repo.SearchByName(keyword));
        }
    }
}
