using FluentValidation;
using TheVideoGameStore.Inventory.Api.Application.Queries;

namespace TheVideoGameStore.Inventory.Api.Application.Validators;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
    }
}
