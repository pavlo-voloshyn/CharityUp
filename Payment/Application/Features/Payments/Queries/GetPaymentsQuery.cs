using MediatR;

namespace PaymentService.Application.Features.Payments.Queries;

public class GetPaymentsQuery : IRequest<List<PaymentViewModel>>
{
}
