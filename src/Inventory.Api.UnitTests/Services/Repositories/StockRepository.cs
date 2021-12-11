using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;

internal class StockRepository : IStockRepository
{
    private readonly List<Stock> _stocks = new();

    public Task<Stock> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = _stocks.SingleOrDefault(x => x.Guid == id);
        return Task.FromResult(result);
    }

    public Task<Stock> AddAsync(Stock stock, CancellationToken cancellationToken = default)
    {
        stock.Guid = Guid.NewGuid();
        _stocks.Add(stock);
        return Task.FromResult(stock);
    }

    public Task UpdateAsync(Guid id, Stock stock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
