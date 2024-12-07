using ApplicationLayer.Features.Courses.Commands;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Courses.Mapping
{
    public class AddCourseCommandMappingProfile : Profile
    {
        public AddCourseCommandMappingProfile()
        {
            CreateMap<AddCourseCommandDTO, Course>()
           .ForMember(dest => dest.PrerequisiteCourse, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.PrerequisiteCourseCode) ? new Course { CourseCode = src.PrerequisiteCourseCode } : null))
           .ForMember(dest => dest.HasPrerequisite, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.PrerequisiteCourseCode) ? false : true));





        }



    }


}
