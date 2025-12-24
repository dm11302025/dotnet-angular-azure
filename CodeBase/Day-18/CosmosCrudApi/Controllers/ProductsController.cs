using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CosmosCrudApi.Contracts;
using CosmosCrudApi.Models;
using CosmosCrudApi.DTO;
namespace CosmosCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),   // MUST execute
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price
            };

            // 🔴 PROOF CHECK
            if (string.IsNullOrWhiteSpace(product.Id))
                return BadRequest("Id generation failed");

            await _repository.CreateAsync(product);
            return Ok(product);
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        // GET BY ID
        [HttpGet("{id}/{category}")]
        public async Task<IActionResult> Get(string id, string category)
        {
            var product = await _repository.GetByIdAsync(id, category);
            return Ok(product);
        }

        // PUT
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _repository.UpdateAsync(product);
            return Ok(product);
        }

        // DELETE
        [HttpDelete("{id}/{category}")]
        public async Task<IActionResult> Delete(string id, string category)
        {
            await _repository.DeleteAsync(id, category);
            return NoContent();
        }
    }

}
