using AutoMapper;
using HandsOnAPIWithModelsAndDTOs.DTOs;
using HandsOnAPIWithModelsAndDTOs.Models;
using HandsOnAPIWithModelsAndDTOs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIWithModelsAndDTOs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAll()
        {
            var products = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetById(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return NotFound();

            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        // CREATE
        [HttpPost]
        public ActionResult<ProductReadDto> Create(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _repo.Add(product);

            var readDto = _mapper.Map<ProductReadDto>(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, readDto);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductUpdateDto dto)
        {
            var product = _repo.GetById(id);
            if (product == null) return NotFound();

            _mapper.Map(dto, product);
            _repo.Update(product);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return NotFound();

            _repo.Delete(id);
            return NoContent();
        }
    }

}
