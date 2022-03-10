using SubscriptionService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SubscriptionService.DataAccess.Presistence.Mapping;

namespace SubscriptionService.DataAccess.Presistence;

public class SubscriptionDbContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; }

    public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SubscriptionConfiguration.Configure(modelBuilder);
    }
}
