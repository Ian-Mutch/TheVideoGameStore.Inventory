using FluentValidation;
using System.Linq;
using System.Linq.Expressions;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Validators.Extensions;

public static class AbstractValidatorExtensions
{
    public static IRuleBuilderOptions<T, string> AddPlatformValidationRule<T>(this AbstractValidator<T> validator, Expression<Func<T, string>> expression, bool allowNulls = false)
    {
        return validator.RuleFor(expression)
                        .Must(e => (allowNulls && e is null) || Domain.SeedWork.Enumeration.GetAll<Platform>()
                                                              .Any(p => p.Name.Equals(e)));
    }

    public static IRuleBuilderOptions<T, string> AddProductTypeValidationRule<T>(this AbstractValidator<T> validator, Expression<Func<T, string>> expression, bool allowNulls = false)
    {
        return validator.RuleFor(expression)
                        .Must(e => (allowNulls && e is null) || Domain.SeedWork.Enumeration.GetAll<ProductType>()
                                                              .Any(p => p.Name.Equals(e)));
    }

}
