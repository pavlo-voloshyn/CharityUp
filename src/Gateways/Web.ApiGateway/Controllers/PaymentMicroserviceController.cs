using AccountService.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.Features.Payments.Commands.Pay;
using PaymentService.Application.Features.Payments.Queries;
using Web.ApiGateway.Services;

namespace Web.ApiGateway.Controllers;

[Route("WebApi/[controller]")]
[ApiController]
public class PaymentMicroserviceController : ControllerBase
{
    private readonly PaymentHttpClientService _paymentHttpClientService;

    public PaymentMicroserviceController(PaymentHttpClientService paymentHttpClientService)
    {
        _paymentHttpClientService = paymentHttpClientService;
    }

    [HttpPost]
    [Authorize(Roles = $"{UserRoles.Benefactor}")]
    public async Task<IActionResult> CreatePayment(PayCommand command)
    {
        var response = await _paymentHttpClientService.PostAsync<PayCommandResponse>("api/payment", command);
        return Ok(response);
    }

    [HttpGet]
    [Authorize(Roles = $"{UserRoles.Admin}")]
    public async Task<IActionResult> GetPayments()
    {
        var response = await _paymentHttpClientService.GetAsync<List<PaymentViewModel>>("api/payment");
        return Ok(response);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Benefactor}")]
    public async Task<IActionResult> GetPaymentByUserId(Guid id)
    {
        var response = await _paymentHttpClientService.GetAsync<PaymentViewModel>($"api/payment/{id}");
        return Ok(response);
    }

    [HttpGet("ByUserId/{userId}")]
    [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Benefactor}")]
    public async Task<IActionResult> GetPaymentsByUserId(Guid userId)
    {
        var response = await _paymentHttpClientService.GetAsync<List<PaymentViewModel>>($"api/payment/ByUserId{userId}");
        return Ok(response);
    }
}
