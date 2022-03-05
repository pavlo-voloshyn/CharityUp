using AutoMapper;
using PaymentService.Domain.Models;
using PaymentService.Application.Features.Payments.Commands.Pay;
using PaymentService.Application.Features.Payments.Queries;

namespace PaymentService.Application.MapperProfiles;

internal class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<PayCommand, Payment>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<Payment, PaymentViewModel>();
    }
}
