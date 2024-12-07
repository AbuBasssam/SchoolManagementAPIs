using ApplicationLayer.Features.Schedule.Queries;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.SectionFeature.Mapping
{
    public class UpdateSectionScheduleMappingProfile : Profile
    {
        public UpdateSectionScheduleMappingProfile()
        {
            CreateMap<ScheduleDTO, DomainLayer.Entities.Schedule>()
                        .ForMember(dest => dest.Class, opt => opt.MapFrom(src => new Class { ClassName = src.ClassName }))
                        .ForMember(dest => dest.WeekSchedule, opt => opt.MapFrom(src => src.WeekSchedule))
                        .ForMember(dest => dest.TimeSlot, opt => opt.MapFrom(src => src.TimeSlot))
                        .ForMember(dest => dest.ClassID, opt => opt.Ignore())
                        .ForMember(dest => dest.Id, opt => opt.Ignore());

            //CreateMap<ScheduleDTO, DomainLayer.Entities.Schedule>()
            //            .ForMember(dest => dest.Class, opt => opt.Ignore())
            //            .ForMember(dest => dest.WeekSchedule, opt => opt.MapFrom(src => src.WeekSchedule))
            //            .ForMember(dest => dest.TimeSlot, opt => opt.MapFrom(src => src.TimeSlot))
            //            .ForMember(dest => dest.ClassID, opt => opt.Ignore())
            //            .ForMember(dest => dest.Id, opt => opt.Ignore());


        }

    }

}


