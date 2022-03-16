using AccountService.Application.Helpers;
using AccountService.Application.Models;
using AccountService.Application.Services.Contracts;
using AccountService.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AccountService.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public AuthService(UserManager<User> userManager,
        IOptions<JwtSettings> jwtSettings,
        SignInManager<User> signInManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<LogInResponseModel> LogIn(LogInRequestModel request)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
        {
            throw new ArgumentException($"User {request.UserName} not found");
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

        if (!result.Succeeded)
        {
            throw new ArgumentException("Password or login is not correct");
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        var token = JwtTokenGenerator.GenerateToken(user.UserName, user.Id, userRoles.ToList(), _jwtSettings.Value);

        return new LogInResponseModel() { Token = token };
    }

    public async Task<SignUpResponseModel> LogUp(SignUpRequestModel request)
    {
        var user = _mapper.Map<User>(request);

        var identityResult = await _userManager.CreateAsync(user, request.Password);

        if (!identityResult.Succeeded)
        {
            throw new ArgumentException(identityResult.Errors.First().Description);
        }

        var identityUser = await _userManager.FindByNameAsync(user.UserName);
        await _userManager.AddToRoleAsync(identityUser, request.Role);

        return _mapper.Map<SignUpResponseModel>(identityUser);
    }
}
