using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Responses;

namespace TheVideoGameStore.Inventory.Api.Application.Queries.Stocks;

public class GetStockByIdQuery : IRequest<StockResponse>
{
    public Guid Id { get; }

    public GetStockByIdQuery(Guid id) => Id = id;
}
