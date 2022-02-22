using Application.Models;
using Application.Services.Contracts;
using AutoMapper;
using DataAccess.Contracts;
using Domain.Models;

namespace Application.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(IMapper mapper, ISubscriptionRepository subscriptionRepository)
    {
        _mapper = mapper;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task CreateSubscription(SubscriptionInsertModel subscription)
    {
        var subscriptionEntity = _mapper.Map<Subscription>(subscription);
        _subscriptionRepository.Add(subscriptionEntity);
        await _subscriptionRepository.SaveChangesAsync();
    }

    public async Task DeleteSubscription(Guid id)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(id);
        
        if (subscription == null)
        {
            throw new ArgumentException("Subscription not found");
        }

        _subscriptionRepository.Delete(subscription);
        await _subscriptionRepository.SaveChangesAsync();
    }

    public async Task<SubscriptionViewModel> GetSubscriptionById(Guid id)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(id);
        
        if (subscription == null)
        {
            throw new ArgumentException("Subscription not found");
        }

        return _mapper.Map<SubscriptionViewModel>(subscription);
    }

    public async Task<List<SubscriptionViewModel>> GetSubscriptions()
    {
        var subscriptions = await _subscriptionRepository.GetAllAsync();
        return _mapper.Map<List<SubscriptionViewModel>>(subscriptions);
    }

    public Task<List<SubscriptionViewModel>> GetSubscriptionsByUserId(Guid userId)
    {
        var subscriptions = await _subscriptionRepository.GetWhere(x => x.UserId == userId);
        return _mapper.Map<List<SubscriptionViewModel>>(subscriptions);
    }

    public Task UpdateSubscription(SubscriptionUpdateModel subscription)
    {
        throw new NotImplementedException();
    }
}
