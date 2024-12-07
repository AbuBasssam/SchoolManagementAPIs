using ApplicationLayer.Features.Classes.Queries;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Classes.Mapping
{
    public class ClassMappingProfile : Profile
    {
        #region Constructure(s)

        public ClassMappingProfile() => CreateMap<Class, ClassQueryDTO>().ReverseMap();

        #endregion
    }
}
