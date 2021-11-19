using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text.Json.Serialization;
using TheVideoGameStore.Inventory.Data.InMemory.Extensions;
using TheVideoGameStore.Inventory.Filters;
using TheVideoGameStore.Inventory.Repositories;

namespace TheVideoGameStore.Inventory;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInventoryDbInMemory();
        services.AddRepositories();
        services.AddControllers(config =>
        {
            config.Filters.Add<ModelValidationFilter>();
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.AddSwaggerDocument(config =>
        {
            config.Title = "Inventory";
            config.DocumentName = "v1";
            config.Version = "1.0.0";
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }

        app.UseInventoryDbInMemorySeedData();

        app.UseHttpsRedirection();

        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
