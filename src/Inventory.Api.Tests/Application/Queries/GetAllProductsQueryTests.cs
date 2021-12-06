using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Queries;
using TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Queries;

public class GetAllProductsQueryTests : TestsBase
{
    [Test]
    public async Task GetAllProducts_Success()
    {
        //Arrange
        var repository = ServiceProvider.GetRequiredService<IProductRepository>();
        await repository.AddProductAsync(new Product
        {
            Name = "Game 01",
            Description = "Description of game 01",
            PlatformId = Platform.XboxOne.Id,
            ProductTypeId = ProductType.VideoGame.Id,
            ReleaseDate = DateTime.Now
        });
        await repository.AddProductAsync(new Product
        {
            Name = "Accessory 01",
            Description = "Description of accessory 02",
            PlatformId = Platform.Playstation4.Id,
            ProductTypeId = ProductType.Accessory.Id,
            ReleaseDate = DateTime.Now
        });
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetAllProductsQuery();

        //Act
        var result = await mediater.Send(query);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void GetAllProducts_ThrowsValidationException()
    {
        //Arrange
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetAllProductsQuery()
        {
            Platform = ""
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