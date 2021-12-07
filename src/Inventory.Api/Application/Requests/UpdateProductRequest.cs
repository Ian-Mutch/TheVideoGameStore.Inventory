using System.ComponentModel.DataAnnotations;

namespace TheVideoGameStore.Inventory.Api.Application.Requests;

public class UpdateProductRequest
{
    [Required, MaxLength(200)]
    public string Name { get; set; }
    [Required, MaxLength(255)]
    public string Description { get; set; }
    [Required, MaxLength(200)]
    public string Platform { get; set; }
    [Required, MaxLength(200)]
    public string ProductType { get; set; }
    public DateTime? ReleaseDate { get; set; }
}
