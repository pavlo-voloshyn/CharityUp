using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Mapping;

public class PaymentConfiguration
{
    public static void Configure(ModelBuilder builder)
    {
        builder.Entity<Payment>()
            .HasKey(p => new { p.Id });

        builder.Entity<Payment>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Entity<Payment>()
            .Property(p => p.UserId)
            .IsRequired();

        builder.Entity<Payment>()
            .Property(p => p.FoundationId)
            .IsRequired();

        builder.Entity<Payment>()
            .Property(p => p.Amount)
            .IsRequired();

        builder.Entity<Payment>()
            .Property(p => p.CreatedDate)
            .IsRequired();
    }
}
