using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.DataAccess.Persistence;

namespace PaymentService.Application.DIConfiguration;

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
