using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class FoundationRequestInsertModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(1900, 2022)]
    public int YearOfFoundation { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    public string Website { get; set; }

    [Required]
    public string IBAN { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
}
