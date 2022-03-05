using PaymentService.Domain.Models;

namespace PaymentService.DataAccess.Contracts;

public interface IPaymentRepository : IRepository<Payment>
{
}
