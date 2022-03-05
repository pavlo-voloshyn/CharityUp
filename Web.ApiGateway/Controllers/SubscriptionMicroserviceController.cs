using Microsoft.AspNetCore.Mvc;
using SubscriptionService.Application.Models;
using Web.ApiGateway.Services;

namespace Web.ApiGateway.Controllers;

[Route("WebApi/[controller]")]
[ApiController]
public class SubscriptionMicroserviceController : ControllerBase
{
    private readonly SubscriptionHttpClientService _subscriptionHttpClientService;

    public SubscriptionMicroserviceController(SubscriptionHttpClientService subscriptionHttpClientService)
    {
        _subscriptionHttpClientService = subscriptionHttpClientService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(SubscriptionInsertModel subscriptionModel)
    {
        await _subscriptionHttpClientService.PostAsync("api/subscription", subscriptionModel);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubscription(SubscriptionUpdateModel subscriptionModel)
    {
        await _subscriptionHttpClientService.PutAsync("api/subscription", subscriptionModel);
        return Ok();
    }

    [HttpDelete("Cancel/{id}")]
    public async Task<IActionResult> CancelSubscription(Guid id)
    {
        await _subscriptionHttpClientService.DeleteAsync($"api/subscription/Cancel/{id}");
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var response = await _subscriptionHttpClientService.GetAsync<List<SubscriptionViewModel>>("api/subscription");
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubscriptionById(Guid id)
    {
        var response = await _subscriptionHttpClientService.GetAsync<SubscriptionViewModel>($"api/subscription/{id}");
        return Ok(response);
    }

    [HttpGet("ByUserId/{id}")]
    public async Task<IActionResult> GetSubscriptionsByUserId(Guid id)
    {
        var response = await _subscriptionHttpClientService.GetAsync<List<SubscriptionViewModel>>($"api/subscription/ByUserId/{id}");
        return Ok(response);
    }
}
