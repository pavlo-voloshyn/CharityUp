using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using SubscriptionService.Application.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace SubscriptionService.Application.Services;

public class QueueService : IQueueService
{
    private readonly IConfiguration _configuration;

    public QueueService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMessageAsync<T>(T message, string queueName)
    {
        var queueClient = new QueueClient(_configuration.GetConnectionString("AzureServiceBus"), queueName);
       
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
        string messageBody = JsonSerializer.Serialize(message, options);
        
        var queueMessage = new Message(Encoding.UTF8.GetBytes(messageBody));

        await queueClient.SendAsync(queueMessage);
    }
}
