using ApplicationLayer.Features.SectionFeature.Queries;
using AutoMapper;

namespace ApplicationLayer.Features.SectionFeature.Mapping
{
    public class SectionMappingProfile : Profile
    {
        public SectionMappingProfile()
            => CreateMap<SectionQueryDTO, DomainLayer.Entities.Section>().ReverseMap();

    }


}


