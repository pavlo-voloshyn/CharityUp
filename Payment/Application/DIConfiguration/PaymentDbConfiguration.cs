using DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DIConfiguration;

public static class PaymentDbConfiguration
{
    public static void ConfigurePaymentDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PaymentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}
