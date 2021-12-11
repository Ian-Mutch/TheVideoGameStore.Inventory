using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Api.Application.Commands.Products;
using TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Commands.Products;

public class UpdateProductCommandTests : TestsBase
{
    [Test]
    public async Task UpdateProductCommand_Success()
    {
        //Arrange
        var currentDateTime = DateTime.UtcNow;
        var repository = ServiceProvider.GetRequiredService<IProductRepository>();
        var product = await repository.AddAsync(new Product(1)
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
        Assert.IsTrue(result);
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
}
