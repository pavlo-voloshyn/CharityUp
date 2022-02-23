﻿namespace Application.Models;

/// <summary>
/// Model for viewing subscription data
/// </summary>
public class SubscriptionViewModel
{
    /// <summary>
    /// Id of subscription
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// User's id who subscribed
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Foundation's id which the benefactor subscribed on
    /// </summary>
    public string FoundationId { get; set; }

    /// <summary>
    /// Amount of money for payment due to subscription
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Date when the benefactor subscribed
    /// </summary>
    public DateTime DateSubscribed { get; set; }

    /// <summary>
    /// Date of end of subscription
    /// </summary>
    public DateTime SubscriptionEnded { get; set; }
}
