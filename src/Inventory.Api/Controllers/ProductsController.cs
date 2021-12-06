using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Net.Mime;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Api.Application.Queries;
using TheVideoGameStore.Inventory.Api.Application.Requests;

namespace TheVideoGameStore.Inventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger = null;
    private readonly IMediator _mediater = null;

    public ProductsController(ILogger<ProductsController> logger,  IMediator mediator)
    {
        _logger = logger;
        _mediater = mediator;
    }

    [HttpGet]
    [OpenApiOperation("GetAllProducts")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsRequest request)
    {
        GetAllProductsQuery query = null;

        try
        {
            query = new GetAllProductsQuery
            {
                Platform = request.Platform,
                ProductType = request.ProductType
            };
            var result = await _mediater.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(5001), ex, "Failed to get all products: {@query}", query);
            throw new Exception("Failed to get all products");
        }
    }

    [HttpGet("{id}")]
    [OpenApiOperation("GetProductById")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        try
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediater.Send(query);
            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(5002), ex, "Failed to get product {id}", id);
            throw new Exception("Failed to get product");
        }
    }

    [HttpPost]
    [OpenApiOperation("AddProduct")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        try
        {
            var command = new AddProductCommand
            {
                Name = request.Name,
                Description = request.Description,
                Platform = request.Platform,
                ProductType = request.ProductType,
                ReleaseDate = request.ReleaseDate
            };
            var result = await _mediater.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(5003), ex, "Failed to add product: {@request}", request);
            throw new Exception("Failed to add product");
        }
    }
}
