using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.AutoMapper.Stocks;

public class ProductProfileTests : TestsBase
{
    [Test]
    public void StockToStockResponse_Success()
    {
        //Arrange
        var mapper = ServiceProvider.GetRequiredService<IMapper>();
        var condition = Condition.New;
        var productId = 52;
        var quantity = 1;
        var product = new Product(productId)
        {
            Guid = Guid.NewGuid()
        };
        var stock = new Stock(product, condition, quantity)
        {
            Guid = Guid.NewGuid()
        };

        //Act
        var result = mapper.Map<StockResponse>(stock);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(stock.Guid, result.Id);
        Assert.AreEqual(stock.ProductId, result.ProductId);
        Assert.AreEqual(stock.Condition.Name, result.Condition);
        Assert.AreEqual(stock.Quantity, result.Quantity);
    }
}
