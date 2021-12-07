using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.AutoMapper;

public class ProductProfileTests : TestsBase
{
    [Test]
    public void ProductToProductResponse_Success()
    {
        //Arrange
        var mapper = ServiceProvider.GetRequiredService<IMapper>();
        var product = new Product
        {
            Name = "Game 01",
            Description = "Description 01",
            PlatformId = Platform.XboxOne.Id,
            ProductTypeId = ProductType.VideoGame.Id,
            ReleaseDate = DateTime.UtcNow
        };

        //Act
        var result = mapper.Map<ProductResponse>(product);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(product.Name, result.Name);
        Assert.AreEqual(product.Description, result.Description);
        Assert.AreEqual(product.ReleaseDate, result.ReleaseDate);
        Assert.AreEqual(nameof(Platform.XboxOne), result.Platform);
        Assert.AreEqual(nameof(ProductType.VideoGame), result.ProductType);
    }
}
