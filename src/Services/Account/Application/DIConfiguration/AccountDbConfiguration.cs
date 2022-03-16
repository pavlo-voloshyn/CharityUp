using AccountService.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Application.DIConfiguration;

public static class AccountDbConfiguration
{
    public static void ConfigureAccountDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AccountDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}
