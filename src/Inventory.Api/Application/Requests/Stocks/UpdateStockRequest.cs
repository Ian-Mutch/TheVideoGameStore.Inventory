using System.ComponentModel.DataAnnotations;

namespace TheVideoGameStore.Inventory.Api.Application.Requests.Stocks;

public class UpdateStockRequest
{
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}
