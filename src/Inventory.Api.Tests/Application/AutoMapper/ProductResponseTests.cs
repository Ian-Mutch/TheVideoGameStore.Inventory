using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Api.UnitTests;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.AutoMapper;

public class ProductResponseTests : TestsBase
{
    [Test]
    public void Test_MapToSingle()
    {
        //Arrange
        var mapper = ServiceProvider.GetRequiredService<IMapper>();
        var product = new Product
        {
            Name = "Game 01",
            Description = "Description 01",
            Platform = Platform.XboxOne,
            ProductType = ProductType.VideoGame,
            ReleaseDate = DateTime.Now
        };

        //Act
        var result = mapper.Map<ProductResponse>(product);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(product.Name, result.Name);
        Assert.AreEqual(product.Description, result.Description);
        Assert.AreEqual(product.ReleaseDate, result.ReleaseDate);
        Assert.AreEqual(product.Platform.Name, result.Platform);
        Assert.AreEqual(product.ProductType.Name, result.ProductType);
    }
}
