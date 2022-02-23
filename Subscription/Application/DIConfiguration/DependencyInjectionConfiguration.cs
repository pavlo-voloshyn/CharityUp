using Application.Services;
using Application.Services.Contracts;
using DataAccess.Contracts;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DIConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionService, SubscriptionService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
