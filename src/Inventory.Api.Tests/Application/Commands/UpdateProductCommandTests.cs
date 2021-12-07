using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Commands;

public class UpdateProductCommandTests : TestsBase
{
    [Test]
    public async Task UpdateProductCommand_Success()
    {
        //Arrange
        var currentDateTime = DateTime.UtcNow;
        var repository = ServiceProvider.GetRequiredService<IProductRepository>();
        var product = await repository.AddProductAsync(new Product
        {
            Name = "Game 01",
            Description = "Description of game 01",
            PlatformId = Platform.XboxOne.Id,
            ProductTypeId = ProductType.VideoGame.Id,
            ReleaseDate = currentDateTime
        });
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var command = new UpdateProductCommand(product.Guid)
        {
            Name = "Game 01",
            Description = "Description of game 01",
            Platform = nameof(Platform.Playstation4),
            ProductType = nameof(ProductType.VideoGame),
            ReleaseDate = currentDateTime
        };

        //Act
        var result = await mediater.Send(command);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(product.Guid, result.Guid);
        Assert.AreEqual(command.Name, result.Name);
        Assert.AreEqual(command.Description, result.Description);
        Assert.AreEqual(command.Platform, result.Platform);
        Assert.AreEqual(command.ProductType, result.ProductType);
        Assert.AreEqual(command.ReleaseDate, result.ReleaseDate);
    }

    [Test]
    public void UpdateProductCommand_ThrowsValidationException()
    {
        //Arrange
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new UpdateProductCommand(Guid.Empty);
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
