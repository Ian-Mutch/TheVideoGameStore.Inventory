using Microsoft.EntityFrameworkCore;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace TheVideoGameStore.Inventory.Infastructure.Repositories;

class StockRepository : IStockRepository
{
    private readonly InventoryContext _context;

    public StockRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<Stock> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = from si in _context.StockItems.AsNoTracking()
                    where si.Guid == id
                    select si;

        return await query.SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<Stock> AddAsync(Stock stock, CancellationToken cancellationToken = default)
    {
        var result = _context.StockItems.Add(stock).Entity;
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);
        return result;
    }

    public async Task UpdateAsync(Guid id, Stock stock, CancellationToken cancellationToken = default)
    {
        var existingStockItem = _context.StockItems.Single(x => x.Guid == id);
        existingStockItem.SetQuantity(stock.Quantity);
        await _context.SaveChangesAsync(cancellationToken:cancellationToken);
    }
}
