namespace Domain.Models;

public class Subscription
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? FoundationId { get; set; }

    public decimal Amount { get; set; }

    public DateTime DateSubscribed { get; set; }

    public DateTime SubscriptionEnded { get; set; }
}
