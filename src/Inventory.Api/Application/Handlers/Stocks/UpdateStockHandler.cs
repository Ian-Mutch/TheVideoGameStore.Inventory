using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Commands.Stocks;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Handlers.Stocks;

public class UpdateStockHandler : IRequestHandler<UpdateStockCommand, bool>
{
    private readonly IStockRepository _stockRepository;

    public UpdateStockHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<bool> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        var stock = await _stockRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
        if (stock == null)
            return false;

        stock.SetQuantity(request.Quantity);
        await _stockRepository.UpdateAsync(request.Id, stock, cancellationToken: cancellationToken);
        return true;
    }
}
