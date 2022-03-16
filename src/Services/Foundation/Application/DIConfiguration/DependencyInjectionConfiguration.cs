using FoundationService.Application.DIConfiguration;
using FoundationService.Application.Services;
using FoundationService.Application.Services.Contracts;
using FoundationService.DataAccess.Contracts;
using FoundationService.DataAccess.Persistence;
using FoundationService.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoundationService.Application.DIConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void ConfigureFoundationDatabaseSettings(this IServiceCollection services, IConfigurationSection section)
    {
        services.Configure<FoundationDatabaseSettings>(section);
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFoundationRequestService, FoundationRequestService>();
        services.AddScoped<IFoundationStoreService, FoundationStoreService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IFoundationRequestRepository, FoundationRequestRepository>();
        services.AddScoped<IFoundationRepository, FoundationRepository>();
    }
}
