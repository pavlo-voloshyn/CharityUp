namespace Application.Models;

/// <summary>
/// Response model after successful reqistration
/// </summary>
public class LogUpResponseModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }
}
