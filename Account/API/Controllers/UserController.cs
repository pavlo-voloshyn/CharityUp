using AccountService.API.Filters;
using AccountService.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(AuditLoggingAttribute))]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _userService.GetAllUsers();
        return Ok(response);
    }
}
