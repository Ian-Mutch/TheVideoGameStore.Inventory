using System.Collections.Generic;
using TheVideoGameStore.Inventory.Models;

namespace TheVideoGameStore.Inventory.Repositories.Abstractions;

public interface IProductRepository
{
    IEnumerable<Product> GetAll(Platform? platform = null, ProductType? productType = null);
}
