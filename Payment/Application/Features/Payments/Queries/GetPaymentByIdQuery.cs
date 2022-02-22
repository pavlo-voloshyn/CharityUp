using MediatR;

namespace Application.Features.Payments.Queries;

public class GetPaymentByIdQuery : IRequest<PaymentViewModel>
{
    public Guid Id { get; set; }
}
