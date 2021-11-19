namespace TheVideoGameStore.Inventory.Models;

public class Product
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public Platform Platform { get; set; }
    public ProductType ProductType { get; set; }
}