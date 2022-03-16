using System.ComponentModel.DataAnnotations;

namespace AccountService.Application.Models;

/// <summary>
/// Model for login
/// </summary>
public class LogInRequestModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
