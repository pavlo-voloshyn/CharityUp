using DataAccess.Contracts;
using DataAccess.Presistence;
using Domain.Models;

namespace DataAccess.Repositories;

public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(SubscriptionDbContext context) : base(context)
    {
    }
}
