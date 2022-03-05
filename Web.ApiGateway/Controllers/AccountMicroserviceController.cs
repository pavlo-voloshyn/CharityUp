using AccountService.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Web.ApiGateway.Services;

namespace Web.ApiGateway.Controllers;

[Route("WebApi/[controller]")]
[ApiController]
public class AccountMicroserviceController : ControllerBase
{
    private readonly AccountHttpClientService _accountHttpClientService;

    public AccountMicroserviceController(AccountHttpClientService accountHttpClientService)
    {
        _accountHttpClientService = accountHttpClientService;
    }

    [HttpPost("Account/SignUp")]
    public async Task<IActionResult> LogUp(SignUpRequestModel signUpRequestModel)
    {
        var response = await _accountHttpClientService.PostAsync<SignUpResponseModel>("api/account/SignUp", signUpRequestModel);
        return Ok(response);
    }

    [HttpPost("Account/LogIn")]
    public async Task<IActionResult> LogIn(LogInRequestModel logInRequestModel)
    {
        var response = await _accountHttpClientService.PostAsync<SignUpResponseModel>("api/account/LogIn", logInRequestModel);
        return Ok(response);
    }

    [HttpGet("User")]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _accountHttpClientService.GetAsync<List<UserModel>>("api/user");
        return Ok(response);
    }
}
