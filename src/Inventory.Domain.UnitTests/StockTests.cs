using NUnit.Framework;
using System;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace Inventory.Domain.UnitTests;
public class StockTests
{
	[Test]
    public void Stock_CreateWithoutQuantity()
    {
        //Arrange
        var productId = 1;
        var condition = Condition.New;

        //Act
        var product = new Product(productId);
        var stock = new Stock(product, Condition.New);

        //Assert
        Assert.NotNull(stock);
        Assert.AreEqual(productId, stock.ProductId);
        Assert.AreEqual(condition.Id, stock.ConditionId);
        Assert.AreEqual(condition, stock.Condition);
        Assert.AreEqual(0, stock.Quantity);
    }

    [Test]
    public void Stock_CreateWithQuantity()
    {
        //Arrange
        var productId = 1;
        var condition = Condition.New;
        var quantity = 2;

        //Act
        var product = new Product(productId);
        var stock = new Stock(product, Condition.New, quantity);

        //Assert
        Assert.NotNull(stock);
        Assert.AreEqual(productId, stock.ProductId);
        Assert.AreEqual(condition.Id, stock.ConditionId);
        Assert.AreEqual(condition, stock.Condition);
        Assert.AreEqual(quantity, stock.Quantity);
    }

    [TestCase(1, null)]
    [TestCase(null, nameof(Condition.New))]
    public void Stock_CreateThrowsArgumentNull(int? productId = null, string conditionName = null)
    {
        //Arrange
        var product = productId.HasValue ? new Product(productId.Value) : null;
        var condition = conditionName != null ? Condition.New : null;

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Stock(product, condition));
    }

    [Test]
    public void Stock_SetQuantity_Success()
    {
        //Arrange
        var productId = 1;
        var product = new Product(productId);
        var stock = new Stock(product, Condition.New);

        //Act
        stock.SetQuantity(2);

        //Assert
        Assert.NotNull(stock);
        Assert.AreEqual(2, stock.Quantity);
    }

    [Test]
    public void Stock_SetQuantity_ThrowsArgumentOutOfRange()
    {
        //Arrange
        var productId = 1;
        var product = new Product(productId);
        var stock = new Stock(product, Condition.New);

        //Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => stock.SetQuantity(-1));
    }
}