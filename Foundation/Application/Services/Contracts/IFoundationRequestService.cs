using Application.Models;

namespace Application.Services.Contracts;

public interface IFoundationRequestService
{
    Task CreateFoundationRequestAsync(FoundationRequestInsertModel model);

    Task UpdateFoundationRequestAsync(FoundationRequestUpdateModel model);

    Task<List<FoundationRequestViewModel>> GetFoundationRequestsAsync();

    Task<FoundationRequestViewModel> GetFoundationRequestAsync(string id);

    Task DeleteFoundationRequestAsync(string id);
}
