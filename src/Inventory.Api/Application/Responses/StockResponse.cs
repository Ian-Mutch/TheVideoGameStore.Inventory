namespace TheVideoGameStore.Inventory.Api.Application.Responses;

public class StockResponse
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public string Condition { get; init; }
    public int Quantity { get; set; }
}
