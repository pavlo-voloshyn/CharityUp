using AutoMapper;
using DataAccess.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Payments.Queries;

public class GetPaymentsByUserIdQueryHandler : IRequestHandler<GetPaymentsByUserIdQuery, List<PaymentViewModel>>
{
    private readonly IMapper mapper;
    private readonly IPaymentRepository paymentRepository;

    public GetPaymentsByUserIdQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
    {
        this.mapper = mapper;
        this.paymentRepository = paymentRepository;
    }

    public Task<List<PaymentViewModel>> Handle(GetPaymentsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var payments = paymentRepository.GetWhere(x => x.UserId == request.UserId);
        return Task.FromResult(mapper.Map<List<PaymentViewModel>>(payments));
    }
}
