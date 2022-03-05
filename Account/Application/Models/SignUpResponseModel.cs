namespace AccountService.Application.Models;

/// <summary>
/// Response model after successful reqistration
/// </summary>
public class SignUpResponseModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }
}
