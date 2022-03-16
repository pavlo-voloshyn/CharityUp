using AutoMapper;
using MediatR;
using PaymentService.DataAccess.Contracts;

namespace PaymentService.Application.Features.Payments.Queries;

public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, List<PaymentViewModel>>
{
    private readonly IMapper mapper;
    private readonly IPaymentRepository paymentRepository;

    public GetPaymentsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
    {
        this.mapper = mapper;
        this.paymentRepository = paymentRepository;
    }

    public async Task<List<PaymentViewModel>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await paymentRepository.GetAllAsync();
        return mapper.Map<List<PaymentViewModel>>(payments);
    }
}
