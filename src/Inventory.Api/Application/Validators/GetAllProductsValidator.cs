using FluentValidation;
using System.Linq;
using TheVideoGameStore.Inventory.Api.Application.Queries;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Validators;

public class GetAllProductsValidator : AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductsValidator()
    {
        RuleFor(e => e.Platform).Must(e => string.IsNullOrEmpty(e) || 
                                            Domain.SeedWork.Enumeration.GetAll<Platform>()
                                                                    .Any(p => p.Name.Equals(e)));

        RuleFor(e => e.ProductType).Must(e => string.IsNullOrEmpty(e) ||
                                                Domain.SeedWork.Enumeration.GetAll<ProductType>()
                                                                        .Any(p => p.Name.Equals(e)));
    }
}
