using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Queries;
using TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Queries;

public class GetProductByIdQueryTests : TestsBase
{
    [Test]
    public async Task GetProductById_Success()
    {
        //Arrange
        var repository = ServiceProvider.GetRequiredService<IProductRepository>();
        var product = await repository.AddProductAsync(new Product
        {
            Name = "Game 01",
            Description = "Description of game 01",
            PlatformId = Platform.XboxOne.Id,
            ProductTypeId = ProductType.VideoGame.Id,
            ReleaseDate = DateTime.Now
        });
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetProductByIdQuery(product.Guid);

        //Act
        var result = await mediater.Send(query);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(product.Guid, result.Guid);
    }

    [Test]
    public void GetProductById_ThrowsValidationException()
    {
        //Arrange
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetProductByIdQuery(Guid.Empty);
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