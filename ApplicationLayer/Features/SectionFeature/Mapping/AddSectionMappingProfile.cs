using ApplicationLayer.Features.SectionFeature.Commands;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Section.Mapping
{
    public class AddSectionMappingProfile : Profile
    {
        public AddSectionMappingProfile()
        {
            CreateMap<AddSectionCommandDTO, DomainLayer.Entities.Section>()
                        .ForMember(dest => dest.SectionNumber, opt => opt.MapFrom(src => src.SectionNumber))
                        .ForMember(dest => dest.SectionType, opt => opt.MapFrom(src => src.SectionType))
                        .ForMember
                        (
                            dest => dest.Course, opt => opt.MapFrom
                            (src =>
                                new Course
                                {
                                    CourseCode = src.CourseCode

                                }

                            )
                        )

                        .ForMember(dest => dest.Schedule, opt => opt.MapFrom
                        (src =>
                            new DomainLayer.Entities.Schedule
                            {
                                WeekSchedule = src.Schedule.WeekSchedule,
                                TimeSlot = src.Schedule.TimeSlot,
                                Class = new Class
                                {
                                    ClassName = src.Schedule.ClassName
                                }
                            }
                        )
                        )


                        .ForMember(dest => dest.CourseID, opt => opt.Ignore()) // Assign CourseID if it’s handled differently
                        .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignored because DTO doesn’t contain ID

                        .ForMember(dest => dest.TeacherID, opt => opt.Ignore()) // Handle teacher assignment separately
                        .ForMember(dest => dest.ScheduleID, opt => opt.Ignore()) // Handle schedule assignment separately
                        .ForMember(dest => dest.Teacher, opt => opt.Ignore()) // Ignored if not part of AddSectionCommandDTO
                        .ForMember(dest => dest.Students, opt => opt.Ignore()) // Ignored since not part of the DTO
                        .ForMember(dest => dest.Attendances, opt => opt.Ignore())// Ignored since not part of the DTO
                        .ForMember(dest => dest.IsOpen, opt => opt.Ignore()); // Set separately if required
                                                                              //    .ForMember(dest => dest.CloseAt, opt => opt.Ignore()); // Set separately if required
        }

    }

}


