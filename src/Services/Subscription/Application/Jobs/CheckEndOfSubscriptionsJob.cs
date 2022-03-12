using Microsoft.Extensions.Logging;
using Quartz;
using SubscriptionService.DataAccess.Contracts;

namespace SubscriptionService.Application.Jobs;

[DisallowConcurrentExecution]
public class CheckEndOfSubscriptionsJob : IJob
{
    private readonly ILogger<CheckEndOfSubscriptionsJob> logger;
    private readonly ISubscriptionRepository subscriptionRepository;

    public CheckEndOfSubscriptionsJob(ILogger<CheckEndOfSubscriptionsJob> logger, ISubscriptionRepository subscriptionRepository)
    {
        this.logger = logger;
        this.subscriptionRepository = subscriptionRepository;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        logger.LogInformation("CheckEndOfSubscriptionsJob started");
        try
        {
            subscriptionRepository.GetWhere(x => x.SubscriptionEnded.ToUniversalTime() < DateTime.UtcNow)
                .ToList()
                .ForEach(x => subscriptionRepository.Delete(x));
            await subscriptionRepository.SaveChangesAsync();
        } 
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex.StackTrace);
        }
        finally
        {
            logger.LogInformation("CheckEndOfSubscriptionsJob ended");
        }
    }
}
