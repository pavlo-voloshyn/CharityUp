using SubscriptionService.Application.Models;

namespace SubscriptionService.Application.Services.Contracts;

/// <summary>
/// Service for manipulation and getting data of database
/// </summary>
public interface ISubscriptionStoreService
{
    /// <summary>
    /// Create subscription in database
    /// </summary>
    /// <param name="subscription">A new subscription</param>
    Task CreateSubscriptionAsync(SubscriptionInsertModel subscription);

    /// <summary>
    /// Update the existing subscription in database
    /// </summary>
    /// <param name="subscription">Updated subscription</param>
    Task UpdateSubscriptionAsync(SubscriptionUpdateModel subscription);

    /// <summary>
    /// Delete subscription by id
    /// </summary>
    /// <param name="id">Id of the existing subscription</param>
    Task DeleteSubscriptionAsync(Guid id);

    /// <summary>
    /// Get all subscriptions
    /// </summary>
    /// <returns>Subscriptions</returns>
    Task<List<SubscriptionViewModel>> GetSubscriptionsAsync();

    /// <summary>
    /// Get a subscription by its id
    /// </summary>
    /// <param name="id">Id of subscription</param>
    /// <returns></returns>
    Task<SubscriptionViewModel> GetSubscriptionByIdAsync(Guid id);

    /// <summary>
    /// Get all user's subscriptions
    /// </summary>
    /// <param name="userId">User id of subscription</param>
    /// <returns></returns>
    Task<List<SubscriptionViewModel>> GetSubscriptionsByUserId(Guid userId);
}
