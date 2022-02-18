using Application.Models.FoundationModels;
using Application.Services.Contracts;
using AutoMapper;
using DataAccess.Contracts;
using Domain.Models;

namespace Application.Services;

/// <summary>
/// The service for manipulation of foundations in db
/// </summary>
public class FoundationService : IFoundationService
{
    private readonly IFoundationRepository foundationRepository;
    private readonly IMapper mapper;

    public FoundationService(
            IFoundationRepository foundationRepository,
            IMapper mapper
        )
    {
        this.foundationRepository = foundationRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Create the new foundation in db as the model sent
    /// </summary>
    /// <param name="model">A new foundation</param>
    public async Task CreateFoundationAsync(FoundationInsertModel model)
    {
        var entity = mapper.Map<Foundation>(model);
        await foundationRepository.CreateAsync(entity);
    }

    /// <summary>
    /// Delete the existing foundation from db by id
    /// </summary>
    /// <param name="id">Id of foundation</param>
    public async Task DeleteFoundationAsync(string id)
    {
        await foundationRepository.RemoveAsync(id);
    }

    /// <summary>
    /// Get the foundation by id from db
    /// </summary>
    /// <param name="id">Id of existing foundation</param>
    /// <returns>Foundation</returns>
    public async Task<FoundationViewModel> GetFoundationAsync(string id)
    {
        var entity = await foundationRepository.GetAsync(id);
        return mapper.Map<FoundationViewModel>(entity);
    }

    /// <summary>
    /// Get all foundations from db
    /// </summary>
    /// <returns>List of foundations</returns>
    public async Task<List<FoundationViewModel>> GetFoundationsAsync()
    {
        var entities = await foundationRepository.GetAsync();
        return mapper.Map<List<FoundationViewModel>>(entities);
    }

    /// <summary>
    /// Update the existing foundation in db due to the model sent
    /// </summary>
    /// <param name="model">A updated foundation</param>
    public async Task UpdateFoundationAsync(FoundationUpdateModel model)
    {
        var entity = mapper.Map<Foundation>(model);
        await foundationRepository.UpdateAsync(model.Id, entity);
    }
}
