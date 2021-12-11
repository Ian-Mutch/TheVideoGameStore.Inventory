using FluentValidation;
using TheVideoGameStore.Inventory.Api.Application.Queries.Products;

namespace TheVideoGameStore.Inventory.Api.Application.Validators.Products;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
    }
}
