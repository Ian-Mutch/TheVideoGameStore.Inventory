using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Queries;
using TheVideoGameStore.Inventory.Api.UnitTests.Services.Repositories;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Queries;

public class ProductResponseTests : TestsBase
{
    [Test]
    public async Task GetAllProducts_Success()
    {
        //Arrange
        var mediater = ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetAllProductsQuery();

        //Act
        var result = await mediater.Send(query);

        //Assert
        Assert.NotNull(result);
        Assert.NotZero(result.Count);
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
        AsyncTestDelegate code = async () => await mediater.Send(query);

        //Act & Assert
        Assert.ThrowsAsync<ValidationException>(code);
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
