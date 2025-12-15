using Application.Commands;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly CreateProductCommandHandler _createHandler;
    private readonly GetProductsQueryHandler _getHandler;

    public ProductsController(
        CreateProductCommandHandler createHandler,
        GetProductsQueryHandler getHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        await _createHandler.HandleAsync(command);
        return Ok("Product created successfully");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getHandler.HandleAsync(new GetProductsQuery());
        return Ok(result);
    }
}
