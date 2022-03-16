using AccountService.DataAccess.Persistence.Mapping;
using AccountService.DataAccess.Persistence.Seeding;
using AccountService.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountService.DataAccess.Persistence;

public class AccountDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<Gender> Genders { get; set; }

    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        GenderConfiguration.Configure(builder);
        UserConfiguration.Configure(builder);

        AccountDbSeeding.Seed(builder);
    }
}
