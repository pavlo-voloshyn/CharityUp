using System.ComponentModel.DataAnnotations;

namespace Application.Models;

/// <summary>
/// The model for updating existing foundation request
/// </summary>
public class FoundationRequestUpdateModel
{
    /// <summary>
    /// Id of existing foundation request
    /// </summary>
    [Required]
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
    [DataType(DataType.EmailAddress)]
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
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
}
