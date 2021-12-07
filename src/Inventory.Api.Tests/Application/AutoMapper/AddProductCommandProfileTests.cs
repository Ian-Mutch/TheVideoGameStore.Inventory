using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.AutoMapper;

public class AddProductCommandProfileTests : TestsBase
{
    [Test]
    public void AddProductCommandToProduct_Success()
    {
        //Arrange
        var mapper = ServiceProvider.GetRequiredService<IMapper>();
        var command = new AddProductCommand
        {
            Name = "Game 01",
            Description = "Description 01",
            Platform = Platform.XboxOne.Name,
            ProductType = ProductType.VideoGame.Name,
            ReleaseDate = DateTime.UtcNow
        };

        //Act
        var result = mapper.Map<Product>(command);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(command.Name, result.Name);
        Assert.AreEqual(command.Description, result.Description);
        Assert.AreEqual(command.ReleaseDate, result.ReleaseDate);
        Assert.AreEqual(command.Platform, Enumeration.GetAll<Platform>().Single(x => x.Id == result.PlatformId).Name);
        Assert.AreEqual(command.ProductType, Enumeration.GetAll<ProductType>().Single(x => x.Id == result.ProductTypeId).Name);
    }
}
