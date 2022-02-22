using MediatR;

namespace Application.Features.Payments.Pay.Commands;

/// <summary>
/// Command for creating payment
/// </summary>
public class PayCommand : IRequest<PayCommandResponse>
{
    /// <summary>
    /// Description for payment
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// User's id who donated
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Foundation's id which was donated
    /// </summary>
    public string FoundationId { get; set; }

    /// <summary>
    /// Amount of donation
    /// </summary>
    public decimal Amount { get; set; }
}
