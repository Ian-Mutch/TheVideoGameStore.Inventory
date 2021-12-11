using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TheVideoGameStore.Inventory.Api.Application.Requests.Products;

public class GetAllProductsRequest
{
    [FromQuery(Name = "platform"), MaxLength(200)]
    public string Platform { get; set; }
    [FromQuery(Name = "productType"), MaxLength(200)]
    public string ProductType { get; set; }
}
