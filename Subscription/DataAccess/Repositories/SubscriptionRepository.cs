using DataAccess.Contracts;
using DataAccess.Presistence;
using Domain.Models;

namespace DataAccess.Repositories;

internal class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(SubscriptionDbContext context) : base(context)
    {
    }
}
