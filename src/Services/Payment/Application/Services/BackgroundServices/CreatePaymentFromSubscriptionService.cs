using MediatR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentService.Application.Constants;
using PaymentService.Application.Features.Payments.Commands.Pay;
using System.Text;
using System.Text.Json;

namespace PaymentService.Application.Services.BackgroundServices;

public class CreatePaymentFromSubscriptionService : BackgroundService
{
    private IQueueClient _queueClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<CreatePaymentFromSubscriptionService> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public CreatePaymentFromSubscriptionService(
        IConfiguration configuration, 
        ILogger<CreatePaymentFromSubscriptionService> logger,
        IServiceScopeFactory serviceScopeFactory)
    {
        _configuration = configuration;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Handle(Message message, CancellationToken cancelToken)
    {
        try
        {
            var body = Encoding.UTF8.GetString(message.Body);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var command = JsonSerializer.Deserialize<PayCommand>(body, options);
            command.Description = "Made from subscription";

            using var scope = _serviceScopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var response = await mediator.Send(command);

            _logger.LogInformation($"Create Payment are: {body}");
            _logger.LogInformation($"Result: {response.Message}");

            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Occured when handling in {nameof(CreatePaymentFromSubscriptionService)}");
        }
    }
    public virtual Task HandleFailureMessage(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
        if (exceptionReceivedEventArgs == null)
        {
            _logger.LogError($"Occured when handling in {nameof(CreatePaymentFromSubscriptionService)}. ExceptionArgs are null");
        }
        else
        {
            _logger.LogError(exceptionReceivedEventArgs.Exception, $"Occured when handling failure message in {nameof(CreatePaymentFromSubscriptionService)}");
        }
        return Task.CompletedTask;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var messageHandlerOptions = new MessageHandlerOptions(HandleFailureMessage)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false,
            };

            _queueClient = new QueueClient(_configuration.GetConnectionString("AzureServiceBus"), Queues.PaymentQueue);
            _queueClient.RegisterMessageHandler(Handle, messageHandlerOptions);

            _logger.LogInformation($"{nameof(CreatePaymentFromSubscriptionService)} service has started.");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Occured when starting service {nameof(CreatePaymentFromSubscriptionService)}");
        }
        
        return Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"{nameof(CreatePaymentFromSubscriptionService)} service has stopped.");
        await _queueClient.CloseAsync();
    }

}
