using PaymentService.Domain.Models;
using PaymentService.DataAccess.Contracts;
using PaymentService.DataAccess.Persistence;

namespace PaymentService.DataAccess.Repositories;

public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(PaymentDbContext context) : base(context)
    {

    }
}
