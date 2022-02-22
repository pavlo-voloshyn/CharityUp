using DataAccess.Contracts;
using DataAccess.Persistence;
using Domain.Models;

namespace DataAccess.Repositories;

public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(PaymentDbContext context) : base(context)
    {

    }
}
