using HandsOnAPIWithModels.Models;
using HandsOnAPIWithModels.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIWithModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        //public ProductController(IProductRepository repo)
        //{
        //    _repo = repo;
        //}
        public ProductController()
        {
            _repo=new ProductRepository();
        }

        // GET: api/product
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _repo.GetAll();
            return Ok(products);
        }

        // GET: api/product/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repo.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var created = _repo.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/product/2
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("ID mismatch");

            var updated = _repo.Update(product);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/product/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.Delete(id);

            if (!result)
                return NotFound();

            return NoContent(); // 204
        }
    }

}
