using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.MapperProfiles;

internal class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<Subscription, SubscriptionViewModel>();
        CreateMap<SubscriptionInsertModel, Subscription>()
            .ForMember(dst => dst.DateSubscribed, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<SubscriptionUpdateModel, Subscription>();
    }
}
