using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Net.Mime;
using TheVideoGameStore.Inventory.Api.Application.Queries;

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
    public async Task<IActionResult> GetAllProducts(string platform = null, string productType = null)
    {
        GetAllProductsQuery query = null;

        try
        {
            query = new GetAllProductsQuery
            {
                Platform = platform,
                ProductType = productType
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
}
