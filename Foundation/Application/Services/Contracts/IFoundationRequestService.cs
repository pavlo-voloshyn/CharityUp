using Application.Models;

namespace Application.Services.Contracts;

/// <summary>
/// The service interface for manipulation of foundation requests in db
/// </summary>
public interface IFoundationRequestService
{
    /// <summary>
    /// Create the new foundation request in db as the model sent
    /// </summary>
    /// <param name="FoundationRequest">A new foundation request</param>
    Task CreateFoundationRequestAsync(FoundationRequestInsertModel FoundationRequest);

    /// <summary>
    /// Update the existing foundation request in db due to the model sent
    /// </summary>
    /// <param name="FoundationRequest">A updated foundation request</param>
    Task UpdateFoundationRequestAsync(FoundationRequestUpdateModel FoundationRequest);

    /// <summary>
    /// Get all foundation requests from db
    /// </summary>
    /// <returns>List of foundation requests</returns>
    Task<List<FoundationRequestViewModel>> GetFoundationRequestsAsync();

    /// <summary>
    /// Get the foundation request by id from db
    /// </summary>
    /// <param name="id">Id of existing foundation request</param>
    /// <returns>Foundation request</returns>
    Task<FoundationRequestViewModel> GetFoundationRequestAsync(string id);

    /// <summary>
    /// Delete the existing foundation request from db by id
    /// </summary>
    /// <param name="id">Id of foundation request</param>
    Task DeleteFoundationRequestAsync(string id);
}
