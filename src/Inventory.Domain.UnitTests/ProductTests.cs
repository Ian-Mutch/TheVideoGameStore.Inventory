using NUnit.Framework;
using System;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace Inventory.Domain.UnitTests;
public class ProductTests
{
	[Test]
    public void Product_CreateSuccess()
    {
        //Arrange
        var productId = 1;

        //Act
        var product = new Product(productId);

        //Assert
        Assert.NotNull(product);
        Assert.AreEqual(productId, product.Id);
    }
}