using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace TheVideoGameStore.Inventory.Api.UnitTests;

public abstract class TestsBase
{
    protected IServiceProvider ServiceProvider { get; private set; }

    [OneTimeSetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddMediatR(typeof(Startup).Assembly);
        services.AddAutoMapper(typeof(Startup).Assembly);

        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();
    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {

    }
}
