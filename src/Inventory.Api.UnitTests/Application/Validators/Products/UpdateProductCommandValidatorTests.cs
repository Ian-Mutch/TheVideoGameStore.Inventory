using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Commands.Products;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Validators.Products;

internal class UpdateProductCommandValidatorTests : TestsBase
{
    [Test]
    public void Validate_Success()
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<UpdateProductCommand>>();
        var command = new UpdateProductCommand(Guid.NewGuid())
        {
            Name = "Game 01",
            Description = "Description",
            ProductType = nameof(ProductType.VideoGame),
            Platform = nameof(Platform.PC)
        };
        void code() => validator.ValidateAndThrow(command);

        //Act & Assert
        Assert.DoesNotThrow(code);
    }

    [TestCase(false, "Name", "Description", nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase(true, "", "Description", nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase(true, "Name", "", nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase(true, "Name", "Description", "", nameof(ProductType.Accessory))]
    [TestCase(true, "Name", "Description", nameof(Platform.Playstation5), "")]
    [TestCase(true, null, "Description", nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase(true, "Name", null, nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase(true, "Name", "Description", null, nameof(ProductType.Accessory))]
    [TestCase(true, "Name", "Description", nameof(Platform.Playstation5), null)]
    public void Validate_ThrowsValidationException(bool createGuid, string name, string description, string platform, string productType)
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<UpdateProductCommand>>();
        var query = new UpdateProductCommand(createGuid ? Guid.NewGuid() : Guid.Empty)
        {
            Name = name,
            Description = description,
            Platform = platform,
            ProductType = productType
        };
        void code() => validator.ValidateAndThrow(query);

        //Act & Assert
        Assert.Throws<ValidationException>(code);
    }
}
