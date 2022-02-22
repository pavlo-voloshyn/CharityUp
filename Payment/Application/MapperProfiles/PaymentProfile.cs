using Application.Features.Payments.Pay.Commands;
using Application.Features.Payments.Queries;
using AutoMapper;
using Domain.Models;

namespace Application.MapperProfiles;

internal class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<PayCommand, Payment>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<Payment, PaymentViewModel>();
    }
}
