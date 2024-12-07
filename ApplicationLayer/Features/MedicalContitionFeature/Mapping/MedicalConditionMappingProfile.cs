using ApplicationLayer.Features.MedicalContitions.Queries;
using AutoMapper;

namespace ApplicationLayer.Features.MedicalContitions.Mapping
{
    public class MedicalConditionMappingProfile : Profile
    {
        public MedicalConditionMappingProfile()
            => CreateMap<MedicalCondition, MedicalContionQueryDTO>().ReverseMap();

    }
}
