using AccountService.Domain.Common;
using FoundationService.Application.Models.FoundationModels;
using FoundationService.Application.Models.FoundationRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ApiGateway.Services;

namespace Web.ApiGateway.Controllers;

[Route("WebApi/[controller]")]
[ApiController]
public class FoundationMicroserviceController : ControllerBase
{
    private readonly FoundationHttpClientService _foundationHttpClientService;

    public FoundationMicroserviceController(FoundationHttpClientService foundationHttpClientService)
    {
        _foundationHttpClientService = foundationHttpClientService;
    }

    #region Foundation

    [HttpGet("Foundation")]
    public async Task<IActionResult> GetAllFoundationsAsync()
    {
        var result = await _foundationHttpClientService.GetAsync<List<FoundationViewModel>>("api/foundation");
        return Ok(result);
    }

    [HttpGet("Foundation/{id}")]
    public async Task<IActionResult> GetFoundationByIdAsync(string id)
    {
        var result = await _foundationHttpClientService.GetAsync<FoundationViewModel>($"api/foundation/{id}");
        return Ok(result);
    }

    [HttpDelete("Foundation/{id}")]
    public async Task<IActionResult> DeleteFoundationAsync(string id)
    {
        await _foundationHttpClientService.DeleteAsync($"api/foundation/{id}");
        return Ok();
    }

    [HttpPost("Foundation")]
    public async Task<IActionResult> CreateFoundationAsync(FoundationInsertModel foundationInsertModel)
    {
        await _foundationHttpClientService.PostAsync("api/foundation", foundationInsertModel);
        return Ok();
    }

    [HttpPut("Foundation")]
    public async Task<IActionResult> UpdateFoundationAsync(FoundationUpdateModel foundationUpdateModel)
    {
        await _foundationHttpClientService.PutAsync("api/foundation", foundationUpdateModel);
        return Ok();
    }
    #endregion

    #region FoundationRequest

    [HttpGet("FoundationRequest")]
    [Authorize(Roles = $"{UserRoles.Admin}")]
    public async Task<IActionResult> GetAllFoundationRequestsAsync()
    {
        var result = await _foundationHttpClientService.GetAsync<List<FoundationRequestViewModel>>("api/FoundationRequest");
        return Ok(result);
    }

    [HttpGet("FoundationRequest/{id}")]
    [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Representative}")]
    public async Task<IActionResult> GetFoundationRequestByIdAsync(string id)
    {
        var result = await _foundationHttpClientService.GetAsync<FoundationRequestViewModel>($"api/FoundationRequest/{id}");
        return Ok(result);
    }

    [HttpDelete("FoundationRequest/{id}")]
    [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Representative}")]
    public async Task<IActionResult> DeleteFoundationRequestAsync(string id)
    {
        await _foundationHttpClientService.DeleteAsync($"api/FoundationRequest/{id}");
        return Ok();
    }

    [HttpPost("FoundationRequest")]
    [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Representative}")]
    public async Task<IActionResult> CreateFoundationRequestAsync(FoundationRequestInsertModel foundationRequestInsertModel)
    {
        await _foundationHttpClientService.PostAsync("api/FoundationRequest", foundationRequestInsertModel);
        return Ok();
    }

    [HttpPut("FoundationRequest")]
    [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Representative}")]
    public async Task<IActionResult> UpdateFoundationRequestAsync(FoundationRequestUpdateModel foundationRequestUpdateModel)
    {
        await _foundationHttpClientService.PutAsync("api/FoundatuonRequest", foundationRequestUpdateModel);
        return Ok();
    }

    [HttpPut("FoundationRequest/approve")]
    [Authorize(Roles = $"{UserRoles.Admin}")]
    public async Task<IActionResult> ApproveFoundationRequestAsync(ApproveFoundationRequestModel approveFoundationRequestModel)
    {
        await _foundationHttpClientService.PutAsync("api/FoundationRequst/approve", approveFoundationRequestModel);
        return Ok();
    }

    #endregion
}
