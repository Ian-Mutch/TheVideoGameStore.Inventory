using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using TheVideoGameStore.Inventory.Models;
using TheVideoGameStore.Inventory.Repositories.Abstractions;

namespace TheVideoGameStore.Inventory.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger = null;
    private readonly IProductRepository _productRepository = null;

    public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    [HttpGet]
    [OpenApiOperation("GetAllProducts")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<Product>> GetAll(Platform? platform = null, ProductType? productType = null)
    {
        try
        {
            var data = _productRepository.GetAll(platform: platform, productType: productType);
            return Ok(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(5001), ex, "Failed to get all products {platform} {productType}", platform, productType);
            throw new Exception("Failed to get all products");
        }
    }
}
