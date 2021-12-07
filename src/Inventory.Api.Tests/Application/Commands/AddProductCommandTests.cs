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
            ReleaseDate = DateTime.UtcNow
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

    [Test]
    public void AddProductCommand_ThrowsValidationException()
    {
        //Arrange
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new AddProductCommand();
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
