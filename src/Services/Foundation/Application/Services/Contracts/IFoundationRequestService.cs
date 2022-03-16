using FoundationService.Application.Models.FoundationRequestModels;

namespace FoundationService.Application.Services.Contracts;

/// <summary>
/// The service interface for manipulation of foundation requests in db
/// </summary>
public interface IFoundationRequestService
{
    /// <summary>
    /// Create the new foundation request in db as the model sent
    /// </summary>
    /// <param name="foundationRequest">A new foundation request</param>
    Task CreateFoundationRequestAsync(FoundationRequestInsertModel foundationRequest);

    /// <summary>
    /// Update the existing foundation request in db due to the model sent
    /// </summary>
    /// <param name="foundationRequest">A updated foundation request</param>
    Task UpdateFoundationRequestAsync(FoundationRequestUpdateModel foundationRequest);

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

    /// <summary>
    /// Approve foundation request. Move request to foundation collection
    /// </summary>
    /// <param name="foundationRequestId">Id of request</param>
    /// <returns></returns>
    Task ApproveFoundationRequestAsync(ApproveFoundationRequestModel approveFoundationRequestModel);
}
