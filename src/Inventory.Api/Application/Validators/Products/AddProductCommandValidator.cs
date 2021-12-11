using FluentValidation;
using TheVideoGameStore.Inventory.Api.Application.Commands.Products;
using TheVideoGameStore.Inventory.Api.Application.Validators.Extensions;

namespace TheVideoGameStore.Inventory.Api.Application.Validators.Products;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty()
                            .MaximumLength(200)
                            .MinimumLength(1);

        RuleFor(e => e.Description).NotEmpty()
                            .MaximumLength(255)
                            .MinimumLength(1);

        this.AddPlatformValidationRule(e => e.Platform);
        this.AddProductTypeValidationRule(e => e.ProductType);
    }
}