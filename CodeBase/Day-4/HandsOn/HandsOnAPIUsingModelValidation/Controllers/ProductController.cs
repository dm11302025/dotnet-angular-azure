using HandsOnAPIUsingModelValidation.Models;
using HandsOnAPIUsingModelValidation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingModelValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
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

            // =====================
            // GET: api/products
            // =====================
            [HttpGet]
            public IActionResult GetAll()
            {
                var products = _repo.GetAll();
                return Ok(products);  // 200 OK
            }

            // =====================
            // GET: api/products/5
            // =====================
            [HttpGet("{id:int}")]
            public IActionResult GetById(int id)
            {
                var product = _repo.GetById(id);

                if (product == null)
                    return NotFound($"Product with Id = {id} not found."); // 404

                return Ok(product); // 200
            }

            // =====================
            // POST: api/products
            // =====================
            [HttpPost]
            public IActionResult Create([FromBody] Product product)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);   // 400

                var created = _repo.Add(product);

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
                // 201 Created
            }

            // =====================
            // PUT: api/products/5
            // =====================
            [HttpPut("{id:int}")]
            public IActionResult Update(int id, [FromBody] Product product)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);   // 400

                var existing = _repo.GetById(id);
                if (existing == null)
                    return NotFound($"Product with Id = {id} not found."); // 404

                product.Id = id;   // ensure ID match
                _repo.Update(product);

                return NoContent();  // 204 No Content
            }

            // =====================
            // DELETE: api/products/5
            // =====================
            [HttpDelete("{id:int}")]
            public IActionResult Delete(int id)
            {
                var existing = _repo.GetById(id);

                if (existing == null)
                    return NotFound($"Product with Id = {id} not found."); // 404

                _repo.Delete(id);

                return NoContent();  // 204
            }
        }

    }
}
