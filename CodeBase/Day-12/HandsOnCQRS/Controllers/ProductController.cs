using HandsOnCQRS.CommandHandlers;
using HandsOnCQRS.Commands;
using HandsOnCQRS.Queries;
using HandsOnCQRS.QueryHandlers;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnCQRS.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommandHandler _create;
        private readonly UpdateProductCommandHandler _update;
        private readonly DeleteProductCommandHandler _delete;
        private readonly GetAllProductsQueryHandler _getAll;
        private readonly GetProductByIdQueryHandler _getById;
        public ProductsController(
            CreateProductCommandHandler create,
            UpdateProductCommandHandler update,
            DeleteProductCommandHandler delete,
            GetAllProductsQueryHandler getAll,
            GetProductByIdQueryHandler getById)
        {
            _create = create;
            _update = update;
            _delete = delete;
            _getAll = getAll;
            _getById = getById;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _create.HandleAsync(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;
            await _update.HandleAsync(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _delete.HandleAsync(new DeleteProductCommand(id));
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _getAll.HandleAsync(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getById.HandleAsync(new GetProductByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }
    }


}
