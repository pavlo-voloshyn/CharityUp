using Web.ApiGateway.Services;

namespace Web.ApiGateway.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<AccountHttpClientService>();
        services.AddSingleton<FoundationHttpClientService>();
        services.AddSingleton<PaymentHttpClientService>();
        services.AddSingleton<SubscriptionHttpClientService>();
    }

    public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("AccountService", config =>
        {
            config.BaseAddress = new Uri(configuration["Services:Account"]);
        });
        services.AddHttpClient("FoundationService", config =>
        {
            config.BaseAddress = new Uri(configuration["Services:Foundation"]);
        });
        services.AddHttpClient("PaymentService", config =>
        {
            config.BaseAddress = new Uri(configuration["Services:Payment"]);
        });
        services.AddHttpClient("SubscriptionService", config =>
        {
            config.BaseAddress = new Uri(configuration["Services:Subscription"]);
        });
    }
}
