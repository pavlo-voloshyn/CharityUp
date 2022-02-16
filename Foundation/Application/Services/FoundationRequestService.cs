using Application.Models;
using Application.Services.Contracts;
using AutoMapper;
using DataAccess.Contracts;
using Domain.Models;

namespace Application.Services;

public class FoundationRequestService : IFoundationRequestService
{
    private readonly IFoundationRequestRepository foundationRequestRepository;
    private readonly IMapper mapper;

    public FoundationRequestService(
            IFoundationRequestRepository foundationRequestRepository,
            IMapper mapper
        )
    {
        this.foundationRequestRepository = foundationRequestRepository;
        this.mapper = mapper;
    }

    public async Task CreateFoundationRequestAsync(FoundationRequestInsertModel model)
    {
        var entity = mapper.Map<FoundationRequest>(model);
        await foundationRequestRepository.CreateAsync(entity);
    }

    public async Task DeleteFoundationRequestAsync(string id)
    {
        await foundationRequestRepository.RemoveAsync(id);
    }

    public async Task<FoundationRequestViewModel> GetFoundationRequestAsync(string id)
    {
        var entity = await foundationRequestRepository.GetAsync(id);
        var resultForView = mapper.Map<FoundationRequestViewModel>(entity);

        return resultForView;
    }

    public async Task<List<FoundationRequestViewModel>> GetFoundationRequestsAsync()
    {
        var entities = await foundationRequestRepository.GetAsync();
        var resultForView = mapper.Map<List<FoundationRequestViewModel>>(entities);

        return resultForView;
    }

    public async Task UpdateFoundationRequestAsync(FoundationRequestUpdateModel model)
    {
        var entity = mapper.Map<FoundationRequest>(model);
        await foundationRequestRepository.UpdateAsync(model.Id, entity);
    }
}
