using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionService.DataAccess.Presistence;

namespace SubscriptionService.Application.DIConfiguration;

public static class SubscriptionDbConfiguration
{
    public static void ConfigureSubscriptionDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SubscriptionDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}
