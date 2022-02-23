using System.ComponentModel.DataAnnotations;

namespace Application.Models;

/// <summary>
/// Model for redister a new user
/// </summary>
public class SignUpRequestModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDay { get; set; }

    [Required]
    public int GenderId { get; set; }

    [Required]
    public string Role { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
