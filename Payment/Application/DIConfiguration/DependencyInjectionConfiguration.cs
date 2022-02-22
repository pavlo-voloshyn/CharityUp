using DataAccess.Contracts;
using DataAccess.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.DIConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPaymentRepository, PaymentRepository>();
    }

    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
