using MediatR;

namespace TheVideoGameStore.Inventory.Api.Application.Commands.Stocks;

public class UpdateStockCommand : IRequest<bool>
{
    public Guid Id { get; }
    public int Quantity { get; init; }

    public UpdateStockCommand(Guid id) => Id = id;
}