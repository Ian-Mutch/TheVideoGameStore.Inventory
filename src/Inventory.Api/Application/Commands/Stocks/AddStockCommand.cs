using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Responses;

namespace TheVideoGameStore.Inventory.Api.Application.Commands.Stocks;

public class AddStockCommand : IRequest<StockResponse>
{
    public Guid ProductId { get; init; }
    public string Condition { get; init; }
    public int Quantity { get; init; }
}