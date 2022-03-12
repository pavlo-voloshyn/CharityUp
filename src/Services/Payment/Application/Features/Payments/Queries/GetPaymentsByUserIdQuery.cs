using MediatR;

namespace PaymentService.Application.Features.Payments.Queries;

/// <summary>
/// Get payments by their user id
/// </summary>
public class GetPaymentsByUserIdQuery : IRequest<List<PaymentViewModel>>
{
    /// <summary>
    /// Úser id of payments
    /// </summary>
    public Guid UserId { get; set; }
}
