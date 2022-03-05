using AccountService.DataAccess.Persistence;
using AccountService.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Application.DIConfiguration;

public static class IdentityServerConfiguration
{
    public static void ConfigureIdentityServer(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AccountDbContext>()
            .AddDefaultTokenProviders();
    }
}
