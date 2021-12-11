namespace TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

public interface IStockRepository : IRepository
{
    Task<Stock> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Stock> AddAsync(Stock stock, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, Stock stock, CancellationToken cancellationToken = default);
}
