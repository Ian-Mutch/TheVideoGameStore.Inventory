using FluentValidation;
using TheVideoGameStore.Inventory.Api.Application.Queries;
using TheVideoGameStore.Inventory.Api.Application.Validators.Extensions;

namespace TheVideoGameStore.Inventory.Api.Application.Validators;

public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductsQueryValidator()
    {
        this.AddPlatformValidationRule(e => e.Platform, true);
        this.AddProductTypeValidationRule(e => e.ProductType, true);
    }
}
