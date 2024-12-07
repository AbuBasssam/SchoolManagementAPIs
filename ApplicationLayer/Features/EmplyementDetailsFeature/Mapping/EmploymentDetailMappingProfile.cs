using ApplicationLayer.Features.EmplyementDetails.Queries;
using AutoMapper;
using DomainLayer.Entities;
namespace ApplicationLayer.Features.EmplyementDetails.Mapping
{
    public class EmploymentDetailMappingProfile : Profile
    {
        public EmploymentDetailMappingProfile()
            => CreateMap<EmploymentDetail, EmplyementDetailQueryDTO>().ReverseMap();

    }

}
