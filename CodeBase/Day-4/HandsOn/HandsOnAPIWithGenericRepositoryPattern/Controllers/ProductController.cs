using HandsOnAPIWithGenericRepositoryPattern.Models;
using HandsOnAPIWithGenericRepositoryPattern.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIWithGenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repo;

        public ProductController(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
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
            if (id != product.Id)
                return BadRequest("ID mismatch");

            var updated = _repo.Update(product);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _repo.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
