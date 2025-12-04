using HandsOnAPIWithGenericRepositoryPattern.Models;
using HandsOnAPIWithGenericRepositoryPattern.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIWithGenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericRepository<Customer> _repo;

        public CustomerController(IGenericRepository<Customer> repo)
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
            var customer = _repo.GetById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var created = _repo.Add(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest("ID mismatch");

            var updated = _repo.Update(customer);
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
