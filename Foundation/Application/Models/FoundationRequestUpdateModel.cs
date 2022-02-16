using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class FoundationRequestUpdateModel
{
    [Required]
    public string Id { get; set; }
 
    public string Name { get; set; }

    public int YearOfFoundation { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public string IBAN { get; set; }

    public string Phone { get; set; }
}
