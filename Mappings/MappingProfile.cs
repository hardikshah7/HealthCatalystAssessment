using AutoMapper;
using HealthCatalystAssessment.Models;

namespace HealthCatalystAssessment.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, Interest>().ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src));
            CreateMap<UserCreation, User>()
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.Interests));
        }
    }
}
