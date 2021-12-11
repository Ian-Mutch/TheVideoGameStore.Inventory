using System.ComponentModel.DataAnnotations;

namespace TheVideoGameStore.Inventory.Api.Application.Requests.Products;

public class UpdateProductRequest
{
    [Required(AllowEmptyStrings = false), MaxLength(200)]
    public string Name { get; set; }
    [Required(AllowEmptyStrings = false), MaxLength(255)]
    public string Description { get; set; }
    [Required(AllowEmptyStrings = false), MaxLength(200)]
    public string Platform { get; set; }
    [Required(AllowEmptyStrings = false), MaxLength(200)]
    public string ProductType { get; set; }
    public DateTime? ReleaseDate { get; set; }
}
