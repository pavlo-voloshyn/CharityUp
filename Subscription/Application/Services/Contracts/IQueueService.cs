namespace SubscriptionService.Application.Services.Contracts;

public interface IQueueService
{
    Task SendMessageAsync<T>(T message, string queueName);
}
