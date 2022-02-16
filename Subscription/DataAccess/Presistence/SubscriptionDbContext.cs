using DataAccess.Presistence.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Presistence;

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
