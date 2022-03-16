using AutoMapper;
using MediatR;
using PaymentService.DataAccess.Contracts;

namespace PaymentService.Application.Features.Payments.Queries;

public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentViewModel>
{
    private readonly IPaymentRepository paymentRepository;
    private readonly IMapper mapper;

    public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
    {
        this.paymentRepository = paymentRepository;
        this.mapper = mapper;
    }

    public async Task<PaymentViewModel> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        var payment = await paymentRepository.GetByIdAsync(request.Id);

        if (payment == null)
        {
            throw new ArgumentException("Payment not found");
        }

        return mapper.Map<PaymentViewModel>(payment);
    }
}
