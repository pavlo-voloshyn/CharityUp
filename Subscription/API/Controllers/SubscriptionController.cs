using Application.Models;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
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

    [HttpDelete("cancel/{id}")]
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

    [HttpGet("byUserId/{id}")]
    public async Task<IActionResult> GetSubscriptionsByUserId(Guid id)
    {
        var response = await _subscriptionService.GetSubscriptionsByUserId(id);
        return Ok(response);
    }
}
