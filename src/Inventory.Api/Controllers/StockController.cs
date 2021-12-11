using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Net.Mime;
using TheVideoGameStore.Inventory.Api.Application.Commands.Stocks;
using TheVideoGameStore.Inventory.Api.Application.Queries.Stocks;
using TheVideoGameStore.Inventory.Api.Application.Requests.Stocks;

namespace TheVideoGameStore.Inventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly ILogger<StockController> _logger = null;
    private readonly IMediator _mediater = null;

    public StockController(ILogger<StockController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediater = mediator;
    }


    [HttpGet("{id}")]
    [OpenApiOperation("GetStockById")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetStockById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogDebug("Processing {action} : Request = {id}", nameof(GetStockById), id);

            var query = new GetStockByIdQuery(id);
            var result = await _mediater.Send(query, cancellationToken: cancellationToken);

            _logger.LogDebug("Finished processing {action} : Result = {@result}", nameof(GetStockById), result);

            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get product {id}", id);
            throw new Exception("Failed to get product");
        }
    }

    [HttpPost]
    [OpenApiOperation("AddStock")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddStock([FromBody] AddStockRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogDebug("Processing {action} : Request = {@request}", nameof(AddStock), request);

            var command = new AddStockCommand
            {
                ProductId = request.ProductId,
                Condition = request.Condition,
                Quantity = request.Quantity
            };
            var result = await _mediater.Send(command, cancellationToken: cancellationToken);

            _logger.LogDebug("Finished processing {action} : Result = {@result}", nameof(AddStock), result);

            return CreatedAtAction(nameof(GetStockById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add stock: {@request}", request);
            throw new Exception("Failed to add stock");
        }
    }

    [HttpPut("{id}")]
    [OpenApiOperation("UpdateStock")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateStock(Guid id, [FromBody] UpdateStockRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogDebug("Processing {action} : Id = {id} : Request = {@request}", nameof(UpdateStock), id, request);

            var command = new UpdateStockCommand(id)
            {
                Quantity = request.Quantity
            };
            var result = await _mediater.Send(command, cancellationToken: cancellationToken);

            _logger.LogDebug("Finished processing {action} : Result = {@result}", nameof(UpdateStock), result);

            return result ? NotFound() : Ok();
        }
        catch (Exception ex)
        {
            var properties = new { id, request };
            _logger.LogError(ex, "Failed to update stock: {@properties}", properties);
            throw new Exception("Failed to update stock");
        }
    }
}
