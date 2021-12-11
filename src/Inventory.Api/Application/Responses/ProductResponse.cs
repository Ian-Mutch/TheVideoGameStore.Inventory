namespace TheVideoGameStore.Inventory.Api.Application.Responses;

public class ProductResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime? ReleaseDate { get; init; }
    public string Platform { get; init; }
    public string ProductType { get; init; }
    public Dictionary<string, int> StockQuantities { get; init; } = new();
}
