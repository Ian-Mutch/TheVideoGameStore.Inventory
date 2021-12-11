using System.ComponentModel.DataAnnotations;

namespace TheVideoGameStore.Inventory.Api.Application.Requests.Stocks;

public class AddStockRequest
{
    public Guid ProductId { get; set; }
    [Required(AllowEmptyStrings = false), MaxLength(200)]
    public string Condition { get; set; }
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}
