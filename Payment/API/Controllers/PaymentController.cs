using Application.Features.Payments.Pay.Commands;
using Application.Features.Payments.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PayCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var response = await mediator.Send(new GetPaymentsQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentByUserId(Guid id)
        {
            var response = await mediator.Send(new GetPaymentByIdQuery() { Id = id });
            return Ok(response);
        }

        [HttpGet("by-user-id/{userId}")]
        public async Task<IActionResult> GetPaymentsByUserId(Guid userId)
        {
            var response = await mediator.Send(new GetPaymentsByUserIdQuery() { UserId = userId });
            return Ok(response);
        }
    }
}
