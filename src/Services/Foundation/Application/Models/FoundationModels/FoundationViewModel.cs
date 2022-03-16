namespace FoundationService.Application.Models.FoundationModels;

/// <summary>
/// The model for viewing existing foundation 
/// </summary>
public class FoundationViewModel
{
    /// <summary>
    /// Id of existing foundation 
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Name of the foundation
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Year of the foundation
    /// </summary>
    public int YearOfFoundation { get; set; }

    /// <summary>
    /// The address of the foundation
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Email of the foundation
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Website of the foundation
    /// </summary>
    public string Website { get; set; }

    /// <summary>
    /// IBAN of account where benefactors should donate
    /// </summary>
    public string IBAN { get; set; }

    /// <summary>
    /// Phone of the foundation
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// The date when the request has been approved and moved to foundation
    /// </summary>
    public DateTime DateOfApproving { get; set; }
}
