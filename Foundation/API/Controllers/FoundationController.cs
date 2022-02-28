using API.Filters;
using Application.Models.FoundationModels;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(AuditLoggingAttribute))]
public class FoundationController : ControllerBase
{
    private readonly IFoundationService foundationService;

    public FoundationController(IFoundationService foundationService)
    {
        this.foundationService = foundationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFoundationsAsync()
    {
        var result = await foundationService.GetFoundationsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFoundationByIdAsync(string id)
    {
        var result = await foundationService.GetFoundationAsync(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoundationAsync(string id)
    {
        await foundationService.DeleteFoundationAsync(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoundationAsync(FoundationInsertModel foundationInsertModel)
    {
        await foundationService.CreateFoundationAsync(foundationInsertModel);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFoundationAsync(FoundationUpdateModel foundationUpdateModel)
    {
        await foundationService.UpdateFoundationAsync(foundationUpdateModel);
        return Ok();
    }
}
