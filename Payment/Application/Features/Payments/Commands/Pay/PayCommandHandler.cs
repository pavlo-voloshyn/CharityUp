using AutoMapper;
using DataAccess.Contracts;
using Domain.Models;
using MediatR;

namespace Application.Features.Payments.Pay.Commands;

public class PayCommandHandler : IRequestHandler<PayCommand, PayCommandResponse>
{
    private readonly IMapper mapper;
    private readonly IPaymentRepository paymentRepository;

    public PayCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
    {
        this.mapper = mapper;
        this.paymentRepository = paymentRepository;
    }

    public async Task<PayCommandResponse> Handle(PayCommand request, CancellationToken cancellationToken)
    {
        var validator = new PayCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var errorMessage = validationResult.Errors.Select(error => error.ErrorMessage).Aggregate((a, b) => $"{a} {b}");
            throw new ArgumentException(errorMessage);
        }

        var payment = mapper.Map<Payment>(request);
        paymentRepository.Add(payment);
        await paymentRepository.SaveChangesAsync();

        return new PayCommandResponse() { Message = "Payment was created successfully" }; 
    }
}
