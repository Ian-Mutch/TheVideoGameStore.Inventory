using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TheVideoGameStore.Inventory.Api.Application.Pipelines.Extensions;
using TheVideoGameStore.Inventory.Api.Filters;
using TheVideoGameStore.Inventory.Domain.Extensions;
using TheVideoGameStore.Inventory.Infastructure.Extensions;

namespace TheVideoGameStore.Inventory.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(typeof(Startup).Assembly)
                .AddMediatRPipelines();

        services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
        services.AddAutoMapper(typeof(Startup).Assembly);
        services.AddDomain();
        services.AddInfastructure();
        services.AddControllers(config =>
        {
            config.Filters.Add<ModelValidationFilter>();
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
