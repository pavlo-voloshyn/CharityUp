﻿using Application.Models;
using Application.Services.Contracts;
using AutoMapper;
using DataAccess.Contracts;
using Domain.Models;

namespace Application.Services;

/// <summary>
/// The service for manipulation of foundation requests in db
/// </summary>
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

    /// <summary>
    /// Create the new foundation request in db as the model sent
    /// </summary>
    /// <param name="model">A new foundation request</param>
    public async Task CreateFoundationRequestAsync(FoundationRequestInsertModel model)
    {
        var entity = mapper.Map<FoundationRequest>(model);
        await foundationRequestRepository.CreateAsync(entity);
    }

    /// <summary>
    /// Delete the existing foundation request from db by id
    /// </summary>
    /// <param name="id">Id of foundation request</param>
    public async Task DeleteFoundationRequestAsync(string id)
    {
        await foundationRequestRepository.RemoveAsync(id);
    }

    /// <summary>
    /// Get the foundation request by id from db
    /// </summary>
    /// <param name="id">Id of existing foundation request</param>
    /// <returns>Foundation request</returns>
    public async Task<FoundationRequestViewModel> GetFoundationRequestAsync(string id)
    {
        var entity = await foundationRequestRepository.GetAsync(id);
        return mapper.Map<FoundationRequestViewModel>(entity);
    }

    /// <summary>
    /// Get all foundation requests from db
    /// </summary>
    /// <returns>List of foundation requests</returns>
    public async Task<List<FoundationRequestViewModel>> GetFoundationRequestsAsync()
    {
        var entities = await foundationRequestRepository.GetAsync();
        return mapper.Map<List<FoundationRequestViewModel>>(entities);
    }

    /// <summary>
    /// Update the existing foundation request in db due to the model sent
    /// </summary>
    /// <param name="model">A updated foundation request</param>
    public async Task UpdateFoundationRequestAsync(FoundationRequestUpdateModel model)
    {
        var entity = mapper.Map<FoundationRequest>(model);
        await foundationRequestRepository.UpdateAsync(model.Id, entity);
    }
}
