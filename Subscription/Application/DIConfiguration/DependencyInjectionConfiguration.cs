using Microsoft.Extensions.DependencyInjection;
using SubscriptionService.Application.DIConfiguration;
using SubscriptionService.Application.Services.Contracts;
using SubscriptionService.Application.Services;
using SubscriptionService.DataAccess.Contracts;
using SubscriptionService.DataAccess.Repositories;

namespace SubscriptionService.Application.DIConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionStoreService, SubscriptionStoreService>();
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
