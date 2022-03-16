using SubscriptionService.Domain.Models;
using SubscriptionService.DataAccess.Contracts;
using SubscriptionService.DataAccess.Presistence;

namespace SubscriptionService.DataAccess.Repositories;

public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(SubscriptionDbContext context) : base(context)
    {
    }
}
