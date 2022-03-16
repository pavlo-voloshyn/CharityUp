using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.Application.DIConfiguration;
using PaymentService.Application.Services.BackgroundServices;
using PaymentService.DataAccess.Contracts;
using PaymentService.DataAccess.Repositories;
using System.Reflection;

namespace PaymentService.Application.DIConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPaymentRepository, PaymentRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddHostedService<CreatePaymentFromSubscriptionService>();
    }

    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    }
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
