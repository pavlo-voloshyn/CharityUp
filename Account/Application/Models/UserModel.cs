using Domain.Models;

namespace Application.Models;

/// <summary>
/// View model of user
/// </summary>
public class UserModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime BirthDay { get; set; }

    public Gender Gender { get; set; }
}
