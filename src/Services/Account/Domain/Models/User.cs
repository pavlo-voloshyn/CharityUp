using Microsoft.AspNetCore.Identity;

namespace AccountService.Domain.Models;

/// <summary>
/// The entity for representing users of the system
/// </summary>
public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? BirthDay { get; set; }

    public int GenderId { get; set; }

    public Gender Gender { get; set; }

}
