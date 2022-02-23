namespace Application.Models;

/// <summary>
/// Response model after successful login
/// </summary>
public class LogInResponseModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Token { get; set; }
}

