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
    public async Task<IActionResult> CreatePayment(PayCommand command)
    {
        var response = await _paymentHttpClientService.PostAsync<PayCommandResponse>("api/payment", command);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetPayments()
    {
        var response = await _paymentHttpClientService.GetAsync<List<PaymentViewModel>>("api/payment");
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentByUserId(Guid id)
    {
        var response = await _paymentHttpClientService.GetAsync<PaymentViewModel>($"api/payment/{id}");
        return Ok(response);
    }

    [HttpGet("ByUserId/{userId}")]
    public async Task<IActionResult> GetPaymentsByUserId(Guid userId)
    {
        var response = await _paymentHttpClientService.GetAsync<List<PaymentViewModel>>($"api/payment/ByUserId{userId}");
        return Ok(response);
    }
}
