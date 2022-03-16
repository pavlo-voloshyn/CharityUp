using AccountService.API.Filters;
using AccountService.Application.Models;
using AccountService.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[TypeFilter(typeof(AuditLoggingAttribute))]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> LogUp(SignUpRequestModel signUpRequestModel)
    {
        var response = await _authService.LogUp(signUpRequestModel);
        return Ok(response);
    }

    [HttpPost("LogIn")]
    public async Task<IActionResult> LogIn(LogInRequestModel logInRequestModel)
    {
        var response = await _authService.LogIn(logInRequestModel);
        return Ok(response);
    }
}
