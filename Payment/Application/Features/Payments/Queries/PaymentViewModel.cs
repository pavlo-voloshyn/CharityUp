namespace Application.Features.Payments.Queries;

/// <summary>
/// View model for payment
/// </summary>
public class PaymentViewModel
{
    public Guid Id { get; set; }

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
    /// Date of donation
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Amount of donation
    /// </summary>
    public decimal Amount { get; set; }
}
