using AutoMapper;
using SubscriptionService.Domain.Models;
using SubscriptionService.Application.Models;
using SubscriptionService.Application.Services.Contracts;
using SubscriptionService.DataAccess.Contracts;

namespace SubscriptionService.Application.Services;

public class SubscriptionStoreService : ISubscriptionStoreService
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionStoreService(IMapper mapper, ISubscriptionRepository subscriptionRepository)
    {
        _mapper = mapper;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task CreateSubscription(SubscriptionInsertModel subscriptionModel)
    {
        var subscription = _mapper.Map<Subscription>(subscriptionModel);
        _subscriptionRepository.Add(subscription);
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
        var subscriptions = _subscriptionRepository.GetWhere(x => x.UserId == userId);
        return Task.FromResult(_mapper.Map<List<SubscriptionViewModel>>(subscriptions));
    }

    public async Task UpdateSubscription(SubscriptionUpdateModel subscriptionModel)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionModel.Id);

        if (subscription == null)
        {
            throw new ArgumentException("Subscription not found");
        }

        _mapper.Map(subscriptionModel, subscription);

        _subscriptionRepository.Update(subscription);
        await _subscriptionRepository.SaveChangesAsync();
    }
}
