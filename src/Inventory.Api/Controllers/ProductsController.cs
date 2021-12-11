using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Net.Mime;
using TheVideoGameStore.Inventory.Api.Application.Commands.Products;
using TheVideoGameStore.Inventory.Api.Application.Queries.Products;
using TheVideoGameStore.Inventory.Api.Application.Requests.Products;

namespace TheVideoGameStore.Inventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger = null;
    private readonly IMediator _mediater = null;

    public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediater = mediator;
    }

    [HttpGet]
    [OpenApiOperation("GetAllProducts")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsRequest request)
    {
        GetAllProductsQuery query = null;

        try
        {
            _logger.LogDebug("Processing {action} : Request = {@request}", nameof(GetAllProducts), request);

            query = new GetAllProductsQuery
            {
                Platform = request.Platform,
                ProductType = request.ProductType
            };
            var result = await _mediater.Send(query);

            _logger.LogDebug("Finished processing {action} : Result = {@result}", nameof(GetAllProducts), result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all products: {@query}", query);
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
            _logger.LogDebug("Processing {action} : Request = {id}", nameof(GetProductById), id);

            var query = new GetProductByIdQuery(id);
            var result = await _mediater.Send(query);

            _logger.LogDebug("Finished processing {action} : Result = {@result}", nameof(GetProductById), result);

            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get product {id}", id);
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
            _logger.LogDebug("Processing {action} : Request = {@request}", nameof(AddProduct), request);

            var command = new AddProductCommand
            {
                Name = request.Name,
                Description = request.Description,
                Platform = request.Platform,
                ProductType = request.ProductType,
                ReleaseDate = request.ReleaseDate
            };
            var result = await _mediater.Send(command);

            _logger.LogDebug("Finished processing {action} : Result = {@result}", nameof(AddProduct), result);

            return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add product: {@request}", request);
            throw new Exception("Failed to add product");
        }
    }

    [HttpPut("{id}")]
    [OpenApiOperation("UpdateProduct")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] AddProductRequest request)
    {
        try
        {
            _logger.LogDebug("Processing {action} : Id = {id} : Request = {@request}", nameof(UpdateProduct), id, request);

            var command = new UpdateProductCommand(id)
            {
                Name = request.Name,
                Description = request.Description,
                Platform = request.Platform,
                ProductType = request.ProductType,
                ReleaseDate = request.ReleaseDate
            };
            var result = await _mediater.Send(command);

            _logger.LogDebug("Finished processing {action} : Result = {@result}", nameof(UpdateProduct), result);

            return result ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            var properties = new { id, request };
            _logger.LogError(ex, "Failed to update product: {@properties}", properties);
            throw new Exception("Failed to update product");
        }
    }
}
