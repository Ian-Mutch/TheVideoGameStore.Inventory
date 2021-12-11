using MediatR;

namespace TheVideoGameStore.Inventory.Api.Application.Commands.Products;

public class UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string ProductType { get; init; }
    public string Platform { get; init; }
    public DateTime? ReleaseDate { get; init; }

    public UpdateProductCommand(Guid id) => Id = id;
}