using MediatR;

namespace Application.Features.Payments.Queries;

public class GetPaymentsByUserIdQuery : IRequest<List<PaymentViewModel>>
{
    public Guid UserId { get; set; }
}
