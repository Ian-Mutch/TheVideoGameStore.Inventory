using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Responses;

namespace TheVideoGameStore.Inventory.Api.Application.Commands;

public class UpdateProductCommand : IRequest<ProductResponse>
{
    public Guid Id { get; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string ProductType { get; init; }
    public string Platform { get; init; }
    public DateTime? ReleaseDate { get; init; }

    public UpdateProductCommand(Guid id) => Id = id;
}