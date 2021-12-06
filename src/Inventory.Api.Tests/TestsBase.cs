using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TheVideoGameStore.Inventory.Api.Application.Pipelines.Extensions;

namespace TheVideoGameStore.Inventory.Api.UnitTests;

public abstract class TestsBase
{
    protected IServiceProvider ServiceProvider { get; private set; }

    [OneTimeSetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddMediatR(typeof(Startup).Assembly)
                .AddMediatRPipelines();
        services.AddAutoMapper(typeof(Startup).Assembly);
        services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();
    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {

    }
}
