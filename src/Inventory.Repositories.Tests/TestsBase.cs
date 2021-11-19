using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using TheVideoGameStore.Inventory.Data.Abstractions;
using TheVideoGameStore.Inventory.Data.InMemory.Extensions;

namespace TheVideoGameStore.Inventory.Repositories.Tests;

public abstract class TestsBase
{
    protected IServiceProvider ServiceProvider { get; private set; }

    [OneTimeSetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();

        var dbContext = ServiceProvider.GetService<IInventoryDbContext>();
        ConfigureTestData(dbContext);
    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddInventoryDbInMemory();
        services.AddRepositories();
    }

    protected virtual void ConfigureTestData(IInventoryDbContext dbContext)
    {
        
    }
}
