using MediatR;

namespace PaymentService.Application.Features.Payments.Queries;

/// <summary>
/// Get a payment by its id 
/// </summary>
public class GetPaymentByIdQuery : IRequest<PaymentViewModel>
{
    /// <summary>
    /// Id of payment
    /// </summary>
    public Guid Id { get; set; }
}
