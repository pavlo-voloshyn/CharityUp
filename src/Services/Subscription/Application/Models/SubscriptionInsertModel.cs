using System.ComponentModel.DataAnnotations;

namespace SubscriptionService.Application.Models;

/// <summary>
/// Model for inserting subscription into database
/// </summary>
public class SubscriptionInsertModel
{
    /// <summary>
    /// User's id who subscribed
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    /// Foundation's id which the benefactor subscribed on
    /// </summary>
    [Required]
    public string FoundationId { get; set; }

    /// <summary>
    /// Amount of money for payment due to subscription
    /// </summary>
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }

    /// <summary>
    /// Date of end of subscription
    /// </summary>
    [Required]
    public DateTime SubscriptionEnded { get; set; }
}
