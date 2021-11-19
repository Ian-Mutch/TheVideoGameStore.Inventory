namespace TheVideoGameStore.Inventory.Data.Models;

public class Product
{
    public int ProductId { get; set; }
    public Guid Guid { get; set; }
    public int ProductDefinitionId { get;set; }
    public int ProductTypeId { get; set; }
    public int PlatformId { get; set; }
    public DateTime? ReleaseDate { get; set; }

    public ProductDefinition ProductDefinition { get; set; }
    public ProductType ProductType { get; set; }
    public Platform Platform { get; set; }
}
