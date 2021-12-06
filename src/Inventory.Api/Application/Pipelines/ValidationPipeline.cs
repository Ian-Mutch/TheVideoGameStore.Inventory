using FluentValidation;
using MediatR;

namespace TheVideoGameStore.Inventory.Api.Application.Pipelines;

public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        foreach (var validator in _validators)
            validator.ValidateAndThrow(request);

        return next();
    }
}