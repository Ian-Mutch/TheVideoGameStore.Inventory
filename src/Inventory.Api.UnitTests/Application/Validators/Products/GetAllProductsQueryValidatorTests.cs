using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Queries.Products;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Validators.Products;

internal class GetAllProductsQueryValidatorTests : TestsBase
{
    [TestCase(null, null)]
    [TestCase(nameof(Platform.Playstation4), null)]
    [TestCase(null, nameof(ProductType.Accessory))]
    [TestCase(nameof(Platform.Playstation4), nameof(ProductType.Accessory))]
    public void Validate_Success(string platform, string productType)
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<GetAllProductsQuery>>();
        var query = new GetAllProductsQuery
        {
            Platform = platform,
            ProductType = productType
        };
        void code() => validator.ValidateAndThrow(query);

        //Act & Assert
        Assert.DoesNotThrow(code);
    }

    [TestCase("", null)]
    [TestCase(null, "")]
    [TestCase("", "")]
    public void Validate_ThrowsValidationException(string platform, string productType)
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<GetAllProductsQuery>>();
        var query = new GetAllProductsQuery
        {
            Platform = platform,
            ProductType = productType
        };
        void code() => validator.ValidateAndThrow(query);

        //Act & Assert
        Assert.Throws<ValidationException>(code);
    }
}
