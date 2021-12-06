using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TheVideoGameStore.Inventory.Api.Application.Pipelines.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddMediatRPipelines(this IServiceCollection services)
    {
        return services.Scan(s => s.FromAssemblyOf<Startup>()
                                .AddClasses(c => c.AssignableTo(typeof(IPipelineBehavior<,>)))
                                .AsImplementedInterfaces()
                                .WithTransientLifetime());
    }
}
