namespace SubscriptionService.Domain.Models;

public class SubscriptionLog
{
    public Guid Id { get; set; }

    public Guid SubscriptionId { get; set; }

    public string Message { get; set; }

    public DateTime CreatedAt { get; set; }
}
