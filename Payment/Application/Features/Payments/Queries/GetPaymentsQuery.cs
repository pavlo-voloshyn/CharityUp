using MediatR;

namespace Application.Features.Payments.Queries;
public class GetPaymentsQuery : IRequest<List<PaymentViewModel>>
{
}
