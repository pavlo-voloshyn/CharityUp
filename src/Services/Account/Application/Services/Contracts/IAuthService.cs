using AccountService.Application.Models;

namespace AccountService.Application.Services.Contracts;

/// <summary>
/// Service for account management
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Register a new user
    /// </summary>
    /// <param name="model">Model of a new user's data</param>
    Task<SignUpResponseModel> LogUp(SignUpRequestModel model);

    /// <summary>
    /// Login user into system
    /// </summary>
    /// <param name="model">Credentials for login</param>
    /// <returns>Model with token</returns>
    Task<LogInResponseModel> LogIn(LogInRequestModel model);
}
