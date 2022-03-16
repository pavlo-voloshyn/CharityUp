using Microsoft.Extensions.DependencyInjection;
using SubscriptionService.Application.DIConfiguration;
using SubscriptionService.Application.Services.Contracts;
using SubscriptionService.Application.Services;
using SubscriptionService.DataAccess.Contracts;
using SubscriptionService.DataAccess.Repositories;
using Quartz;
using SubscriptionService.Application.Jobs;

namespace SubscriptionService.Application.DIConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionStoreService, SubscriptionStoreService>();
        services.AddTransient<IQueueService, QueueService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static void ConfigureQuartz(this IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            var jobKey = new JobKey(nameof(CheckEndOfSubscriptionsJob));

            q.AddJob<CheckEndOfSubscriptionsJob>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity($"{nameof(CheckEndOfSubscriptionsJob)}-trigger") 
                .WithCronSchedule("0 * * ? * *"));

            jobKey = new JobKey(nameof(SendPaymentsFromSubscriptionJob));

            q.AddJob<SendPaymentsFromSubscriptionJob>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity($"{nameof(SendPaymentsFromSubscriptionJob)}-trigger")
                .WithCronSchedule("0 * * ? * *"));

        });

        services.AddQuartzHostedService(
            q => q.WaitForJobsToComplete = true);

    }
}
