using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.UnitTests.Application.Validators;

internal class AddProductCommandValidatorTests : TestsBase
{
    [Test]
    public void Validate_Success()
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<AddProductCommand>>();
        var command = new AddProductCommand
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

    [TestCase("", "Description", nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase("Name", "", nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase("Name", "Description", "", nameof(ProductType.Accessory))]
    [TestCase("Name", "Description", nameof(Platform.Playstation5), "")]
    [TestCase(null, "Description", nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase("Name", null, nameof(Platform.Playstation5), nameof(ProductType.Accessory))]
    [TestCase("Name", "Description", null, nameof(ProductType.Accessory))]
    [TestCase("Name", "Description", nameof(Platform.Playstation5), null)]
    public void Validate_ThrowsValidationException(string name, string description, string platform, string productType)
    {
        //Arrange
        var validator = ServiceProvider.GetRequiredService<IValidator<AddProductCommand>>();
        var query = new AddProductCommand
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
