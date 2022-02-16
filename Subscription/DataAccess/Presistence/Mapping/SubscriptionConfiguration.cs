using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Presistence.Mapping;

public class SubscriptionConfiguration
{
    public static void Configure(ModelBuilder builder)
    {
        builder.Entity<Subscription>()
            .HasKey(x => new { x.Id });

        builder.Entity<Subscription>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Entity<Subscription>()
            .Property(x => x.UserId)
            .IsRequired();

        builder.Entity<Subscription>()
            .Property(x => x.DateSubscribed)
            .IsRequired();

        builder.Entity<Subscription>()
            .Property(x => x.FoundationId)
            .IsRequired();

        builder.Entity<Subscription>()
            .Property(x => x.SubscriptionEnded)
            .IsRequired();

        builder.Entity<Subscription>()
            .Property(x => x.Amount)
            .IsRequired();
    }
}
