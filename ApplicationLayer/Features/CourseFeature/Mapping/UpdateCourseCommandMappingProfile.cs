using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Courses.Mapping
{
    public class UpdateCourseCommandMappingProfile : Profile
    {
        public UpdateCourseCommandMappingProfile()
            => CreateMap<UpdateCourseCommandDTO, Course>().ReverseMap();

    }




}
