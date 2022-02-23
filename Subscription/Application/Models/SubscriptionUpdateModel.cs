using System.ComponentModel.DataAnnotations;

namespace Application.Models;

/// <summary>
/// Model for updating subscription info
/// </summary>
public class SubscriptionUpdateModel
{
    /// <summary>
    /// Id of subscription
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// Amount of money for payment due to subscription
    /// </summary>
    [Required]
    public decimal Amount { get; set; }

    /// <summary>
    /// Date of end of subscription
    /// </summary>
    [Required]
    public DateTime SubscriptionEnded { get; set; }
}
