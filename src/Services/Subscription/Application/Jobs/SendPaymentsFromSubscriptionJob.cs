using Microsoft.Extensions.Logging;
using Quartz;
using SubscriptionService.Application.Constants;
using SubscriptionService.Application.Models;
using SubscriptionService.Application.Services.Contracts;

namespace SubscriptionService.Application.Jobs;

public class SendPaymentsFromSubscriptionJob : IJob
{
    private readonly ILogger<SendPaymentsFromSubscriptionJob> _logger;
    private readonly ISubscriptionStoreService _subscriptionStoreService;
    private readonly IQueueService _queueService;

    public SendPaymentsFromSubscriptionJob(
        ILogger<SendPaymentsFromSubscriptionJob> logger,
        ISubscriptionStoreService subscriptionStoreService,
        IQueueService queueService)
    {
        _logger = logger;
        _subscriptionStoreService = subscriptionStoreService;
        _queueService = queueService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("SendPaymentsFromSubscriptionJob started");
        try
        {
            List<SubscriptionViewModel> subscriptions = await _subscriptionStoreService.GetSubscriptionsAsync();
            subscriptions.ForEach(async subscription => await _queueService.SendMessageAsync(subscription, Queues.PaymentQueue));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Exception occured in SendPaymentsFromSubscriptionJob");
        }
        finally
        {
            _logger.LogInformation("SendPaymentsFromSubscriptionJob ended");
        }
    }
}
