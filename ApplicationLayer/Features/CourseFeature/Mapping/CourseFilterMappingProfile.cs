using ApplicationLayer.Features.Classes.Queries.Get_Filter_Classes;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Courses.Mapping
{
    public class CourseFilterMappingProfile : Profile
    {
        public CourseFilterMappingProfile()
            => CreateMap<FilterClassesDTO, FilterClasses>().ReverseMap();

    }




}
