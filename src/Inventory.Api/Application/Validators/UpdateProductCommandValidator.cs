using FluentValidation;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Api.Application.Validators.Extensions;

namespace TheVideoGameStore.Inventory.Api.Application.Validators;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
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