using ApplicationLayer.Features.Courses.Commands;
using ApplicationLayer.Features.Courses.Queries;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Courses.Mapping
{
    public class CourseQueryMappingProfile : Profile
    {
        public CourseQueryMappingProfile()
        {
            CreateMap<Course, CourseQueryDTO>()
             .ConstructUsing
             (
                src =>
                new CourseQueryDTO
                (
                    src.CourseCode,
                    src.CourseName,
                    src.CourseHours,
                    src.CourseLevel,
                    src.HasPractical,
                    src.HasPrerequisite,
                    src.PrerequisiteCourse != null ?
                    src.PrerequisiteCourse.CourseCode : null
                )
             );

            CreateMap<AddCourseCommandDTO, CourseQueryDTO>().ConstructUsing
            (
               src =>
                new CourseQueryDTO
                (
                    src.CourseCode,
                    src.CourseName,
                    src.CourseHours,
                    src.CourseLevel,
                    src.HasPractical,
               !string.IsNullOrWhiteSpace(src.PrerequisiteCourseCode),
                    string.IsNullOrWhiteSpace(src.PrerequisiteCourseCode) ?
                    string.Empty :
                    src.PrerequisiteCourseCode
                )
            );

            // CreateMap<CourseQueryDTO, Course>()
            //.ForMember(dest => dest.PrerequisiteID, opt =>
            //    opt.MapFrom(src => src.PrerequisiteCourseCode == null ? (int?)null : null))
            //.ForMember(dest => dest.PrerequisiteCourse, opt =>
            //    opt.Ignore()); // Assuming you might want to handle this differently

            //  CreateMap<CourseQueryDTO, Course>()
            //.ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode))
            //.ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
            //.ForMember(dest => dest.CourseHours, opt => opt.MapFrom(src => src.CourseHours))
            //.ForMember(dest => dest.CourseLevel, opt => opt.MapFrom(src => src.CourseLevel))
            //.ForMember(dest => dest.HasPractical, opt => opt.MapFrom(src => src.HasPractical))
            //.ForMember(dest => dest.HasPrerequisite, opt => opt.MapFrom(src => src.PrerequisiteCourseCode == null ? false : true))
            //.ForMember(dest => dest.PrerequisiteCourse, opt => opt.Ignore()) // Assuming you might want to handle this differently
            //.ForMember(dest => dest.CourseSections, opt => opt.Ignore())
            //.ForMember(dest => dest.CourseAssignments, opt => opt.Ignore())
            //.ForMember(dest => dest.PrerequisiteCourse, opt => opt.Ignore());


        }
    }


}
