using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Queries.Products;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Validators.Products;

internal class GetProductByIdQueryValidatorTests : TestsBase
{
    [Test]
    public void Validate_Success()
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<GetProductByIdQuery>>();
        var query = new GetProductByIdQuery(Guid.NewGuid());
        void code() => validator.ValidateAndThrow(query);

        //Act & Assert
        Assert.DoesNotThrow(code);
    }

    [Test]
    public void Validate_ThrowsValidationException()
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<GetProductByIdQuery>>();
        var query = new GetProductByIdQuery(Guid.Empty);
        void code() => validator.ValidateAndThrow(query);

        //Act & Assert
        Assert.Throws<ValidationException>(code);
    }
}
