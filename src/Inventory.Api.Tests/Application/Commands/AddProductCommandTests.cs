using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Commands;

public class AddProductCommandTests : TestsBase
{
    [Test]
    public async Task AddProductCommand_Success()
    {
        //Arrange
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var command = new AddProductCommand
        {
            Name = "Game 01",
            Description = "Description of game 01",
            Platform = nameof(Platform.XboxOne),
            ProductType = nameof(ProductType.VideoGame),
            ReleaseDate = DateTime.Now
        };

        //Act
        var result = await mediater.Send(command);

        //Assert
        Assert.NotNull(result);
        Assert.AreNotEqual(Guid.Empty, result.Guid);
        Assert.AreEqual(command.Name, result.Name);
        Assert.AreEqual(command.Description, result.Description);
        Assert.AreEqual(command.Platform, result.Platform);
        Assert.AreEqual(command.ProductType, result.ProductType);
        Assert.AreEqual(command.ReleaseDate, result.ReleaseDate);
    }

    [TestCase("", "Description", nameof(Platform.XboxOne), nameof(ProductType.VideoGame))]
    [TestCase("Name", "", nameof(Platform.XboxOne), nameof(ProductType.VideoGame))]
    [TestCase("Name", "Description", "", nameof(ProductType.VideoGame))]
    [TestCase("Name", "Description", nameof(Platform.XboxOne), "")]
    [TestCase(null, "Description", nameof(Platform.XboxOne), nameof(ProductType.VideoGame))]
    [TestCase("Name", null, nameof(Platform.XboxOne), nameof(ProductType.VideoGame))]
    [TestCase("Name", "Description", null, nameof(ProductType.VideoGame))]
    [TestCase("Name", "Description", nameof(Platform.XboxOne), null)]
    [TestCase("Name", "Description", null, null)]
    [TestCase(null, null, null, null)]
    public void AddProductCommand_ThrowsValidationException(string name, string description, string platform, string productType)
    {
        //Arrange
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new AddProductCommand()
        {
            Name = name,
            Description = description,
            Platform = platform,
            ProductType = productType
        };
        async Task code() => await mediater.Send(query);

        //Act & Assert
        Assert.ThrowsAsync<ValidationException>(code);
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
