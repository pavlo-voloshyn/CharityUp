using PaymentService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using PaymentService.DataAccess.Mapping;

namespace PaymentService.DataAccess.Persistence;

public class PaymentDbContext : DbContext
{
    public DbSet<Payment> Payments { get; set; }

    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        PaymentConfiguration.Configure(modelBuilder);
    }
}
