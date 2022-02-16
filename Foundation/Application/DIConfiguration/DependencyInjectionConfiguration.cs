using Application.Services;
using Application.Services.Contracts;
using DataAccess.Contracts;
using DataAccess.Persistence;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DIConfiguration;

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
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFoundationRequestRepository, FoundationRequestRepository>();
    }
}
