using HandsOnAPIUsingActionResults.Models;
using HandsOnAPIUsingActionResults.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingActionResults.Controllers
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
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _repo.Get(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _repo.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("Id mismatch");

            var existing = _repo.Get(id);
            if (existing == null)
                return NotFound();

            _repo.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repo.Get(id);
            if (existing == null)
                return NotFound();

            _repo.Delete(id);
            return NoContent();
        }
    }

}
