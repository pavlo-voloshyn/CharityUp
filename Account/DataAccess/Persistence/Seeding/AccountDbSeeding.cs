using AccountService.Domain.Common;
using AccountService.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountService.DataAccess.Persistence.Seeding
{
    public class AccountDbSeeding
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Gender>()
                .HasData
                (
                    new Gender() { Id = 1, Name = "Male" },
                    new Gender() { Id = 2, Name = "Female" },
                    new Gender() { Id = 3, Name = "Not specify" }
                );

            builder.Entity<IdentityRole<Guid>>()
                .HasData
                (
                    new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = UserRoles.Admin, NormalizedName = UserRoles.Admin.ToUpper() },
                    new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = UserRoles.Representative, NormalizedName = UserRoles.Representative.ToUpper() },
                    new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = UserRoles.Benefactor, NormalizedName = UserRoles.Benefactor.ToUpper() }
                );
        }
    }
}
