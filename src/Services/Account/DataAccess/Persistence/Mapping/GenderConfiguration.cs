using AccountService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.DataAccess.Persistence.Mapping;

public class GenderConfiguration
{
    public static void Configure(ModelBuilder builder)
    {
        builder.Entity<Gender>()
            .HasKey(x => x.Id);

        builder.Entity<Gender>()
            .Property(g => g.Id)
            .ValueGeneratedOnAdd();

        builder.Entity<Gender>()
            .Property(g => g.Name)
            .IsRequired();
    }
}
