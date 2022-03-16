using AccountService.Application.DIConfiguration;
using AccountService.Application.Models;
using AccountService.Application.Services;
using AccountService.Application.Services.Contracts;
using AccountService.DataAccess.Contracts;
using AccountService.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Application.DIConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
    public static void ConfigureJwtSettings(this IServiceCollection services, IConfigurationSection section)
    {
        services.Configure<JwtSettings>(section);
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

}
