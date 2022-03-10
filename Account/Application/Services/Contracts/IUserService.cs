using AccountService.Application.Models;

namespace AccountService.Application.Services.Contracts;

/// <summary>
/// Service for manipulation and getting data of users in database
/// </summary>
public interface IUserService
{
    Task<List<UserModel>> GetAllUsers();
}
