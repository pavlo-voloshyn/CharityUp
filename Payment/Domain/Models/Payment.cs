namespace Domain.Models;

/// <summary>
/// The entity for saving history of payments of donations
/// </summary>
public class Payment
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
