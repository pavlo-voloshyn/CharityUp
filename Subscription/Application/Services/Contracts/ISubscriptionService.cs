﻿using Application.Models;

namespace Application.Services.Contracts;

/// <summary>
/// Service for manipulation and getting data of database
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Create subscription in database
    /// </summary>
    /// <param name="subscription">A new subscription</param>
    Task CreateSubscription(SubscriptionInsertModel subscription);

    /// <summary>
    /// Update the existing subscription in database
    /// </summary>
    /// <param name="subscription">Updated subscription</param>
    Task UpdateSubscription(SubscriptionUpdateModel subscription);

    /// <summary>
    /// Delete subscription by id
    /// </summary>
    /// <param name="id">Id of the existing subscription</param>
    Task DeleteSubscription(Guid id);

    /// <summary>
    /// Get all subscriptions
    /// </summary>
    /// <returns>Subscriptions</returns>
    Task<List<SubscriptionViewModel>> GetSubscriptions();
    
    /// <summary>
    /// Get a subscription by its id
    /// </summary>
    /// <param name="id">Id of subscription</param>
    /// <returns></returns>
    Task<SubscriptionViewModel> GetSubscriptionById(Guid id);

    /// <summary>
    /// Get all user's subscriptions
    /// </summary>
    /// <param name="userId">User id of subscription</param>
    /// <returns></returns>
    Task<List<SubscriptionViewModel>> GetSubscriptionsByUserId(Guid userId);
}
