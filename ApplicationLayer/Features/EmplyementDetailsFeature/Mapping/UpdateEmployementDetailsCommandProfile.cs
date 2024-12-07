using ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails;
using AutoMapper;
using DomainLayer.Entities;
namespace ApplicationLayer.Features.EmplyementDetails.Mapping
{
    public class UpdateEmployementDetailsCommandProfile : Profile
    {
        public UpdateEmployementDetailsCommandProfile()
            => CreateMap<EmploymentDetail, UpdateEmployementDetailsCommandDTO>().ReverseMap();

    }


}
