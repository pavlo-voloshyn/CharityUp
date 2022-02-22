namespace Application.Models;

/// <summary>
/// Model for updating subscription info
/// </summary>
public class SubscriptionUpdateModel
{
    /// <summary>
    /// Id of subscription
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Amount of money for payment due to subscription
    /// </summary>
    public decimal Amount { get; set; }
       
    /// <summary>
    /// Date of end of subscription
    /// </summary>
    public DateTime SubscriptionEnded { get; set; }
}
