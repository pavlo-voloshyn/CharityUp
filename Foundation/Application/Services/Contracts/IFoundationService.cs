using Application.Models.FoundationModels;

namespace Application.Services.Contracts;

/// <summary>
/// The service for manipulation foundations in database
/// </summary>
public interface IFoundationService
{
    /// <summary>
    /// Create the new foundation in db as the model sent
    /// </summary>
    /// <param name="foundation">A new foundation</param>
    Task CreateFoundationAsync(FoundationInsertModel foundation);

    /// <summary>
    /// Update the existing foundation in db due to the model sent
    /// </summary>
    /// <param name="foundation">A updated foundation</param>
    Task UpdateFoundationAsync(FoundationUpdateModel foundation);

    /// <summary>
    /// Get all foundations from db
    /// </summary>
    /// <returns>List of foundation</returns>
    Task<List<FoundationViewModel>> GetFoundationsAsync();

    /// <summary>
    /// Get the foundation by id from db
    /// </summary>
    /// <param name="id">Id of existing foundation</param>
    /// <returns>Foundation</returns>
    Task<FoundationViewModel> GetFoundationAsync(string id);

    /// <summary>
    /// Delete the existing foundation from db by id
    /// </summary>
    /// <param name="id">Id of foundation</param>
    Task DeleteFoundationAsync(string id);
}
