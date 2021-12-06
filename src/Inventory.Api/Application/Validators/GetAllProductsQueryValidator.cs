using FluentValidation;
using System.Linq;
using TheVideoGameStore.Inventory.Api.Application.Queries;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Validators;

public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductsQueryValidator()
    {
        RuleFor(e => e.Platform).Must(e => Domain.SeedWork.Enumeration.GetAll<Platform>()
                                                                    .Any(p => p.Name.Equals(e)))
                                .When(e => e.Platform is not null);

        RuleFor(e => e.ProductType).Cascade(CascadeMode.Stop).NotEmpty()
                                .Must(e => Domain.SeedWork.Enumeration.GetAll<ProductType>()
                                                                    .Any(p => p.Name.Equals(e)))
                                .When(e => e.ProductType is not null);
    }
}
