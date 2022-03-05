using Microsoft.AspNetCore.Mvc;
using SubscriptionService.API.Filters;
using SubscriptionService.Application.Models;
using SubscriptionService.Application.Services.Contracts;

namespace SubscriptionService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(AuditLoggingAttribute))]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionStoreService _subscriptionService;

    public SubscriptionController(ISubscriptionStoreService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(SubscriptionInsertModel subscriptionModel)
    {
        await _subscriptionService.CreateSubscription(subscriptionModel);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubscription(SubscriptionUpdateModel subscriptionModel)
    {
        await _subscriptionService.UpdateSubscription(subscriptionModel);
        return Ok();
    }

    [HttpDelete("Cancel/{id}")]
    public async Task<IActionResult> CancelSubscription(Guid id)
    {
        await _subscriptionService.DeleteSubscription(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var response = await _subscriptionService.GetSubscriptions();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubscriptionById(Guid id)
    {
        var response = await _subscriptionService.GetSubscriptionById(id);
        return Ok(response);
    }

    [HttpGet("ByUserId/{id}")]
    public async Task<IActionResult> GetSubscriptionsByUserId(Guid id)
    {
        var response = await _subscriptionService.GetSubscriptionsByUserId(id);
        return Ok(response);
    }
}
