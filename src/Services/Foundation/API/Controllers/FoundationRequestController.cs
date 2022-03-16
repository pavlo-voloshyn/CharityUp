using FoundationService.API.Filters;
using FoundationService.Application.Models.FoundationRequestModels;
using FoundationService.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FoundationService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(AuditLoggingAttribute))]
public class FoundationRequestController : ControllerBase
{
    private readonly IFoundationRequestService foundationRequestService;

    public FoundationRequestController(IFoundationRequestService foundationRequestService)
    {
        this.foundationRequestService = foundationRequestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFoundationRequestsAsync()
    {
        var result = await foundationRequestService.GetFoundationRequestsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFoundationRequestByIdAsync(string id)
    {
        var result = await foundationRequestService.GetFoundationRequestAsync(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoundationRequestAsync(string id)
    {
        await foundationRequestService.DeleteFoundationRequestAsync(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoundationRequestAsync(FoundationRequestInsertModel foundationRequestInsertModel)
    {
        await foundationRequestService.CreateFoundationRequestAsync(foundationRequestInsertModel);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFoundationRequestAsync(FoundationRequestUpdateModel foundationRequestUpdateModel)
    {
        await foundationRequestService.UpdateFoundationRequestAsync(foundationRequestUpdateModel);
        return Ok();
    }

    [HttpPut("approve")]
    public async Task<IActionResult> ApproveFoundationRequestAsync(ApproveFoundationRequestModel approveFoundationRequestModel)
    {
        await foundationRequestService.ApproveFoundationRequestAsync(approveFoundationRequestModel);
        return Ok();
    }
}
