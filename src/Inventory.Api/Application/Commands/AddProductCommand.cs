using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Responses;

namespace TheVideoGameStore.Inventory.Api.Application.Commands;

public class AddProductCommand : IRequest<ProductResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProductType { get; init; }
    public string Platform { get; init; }
    public DateTime? ReleaseDate { get; init; }
}
