namespace TheVideoGameStore.Inventory.Api.Application.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string Platform { get; set; }
    public string ProductType { get; set; }
}
