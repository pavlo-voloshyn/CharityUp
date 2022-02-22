using AutoMapper;
using DataAccess.Contracts;
using Domain.Models;
using MediatR;

namespace Application.Features.Payments.Pay.Commands;

public class PayCommandHandler : IRequestHandler<PayCommand, PayCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public PayCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
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

        var payment = _mapper.Map<Payment>(request);
        _paymentRepository.Add(payment);
        await _paymentRepository.SaveChangesAsync();

        return new PayCommandResponse() { Message = "Payment has been made successfully" }; 
    }
}
