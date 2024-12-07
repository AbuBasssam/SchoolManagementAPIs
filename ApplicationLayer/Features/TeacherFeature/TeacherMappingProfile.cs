using ApplicationLayer.Features.Teachers.Commands.AddNewTeacher;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Teacher
{
    public class TeacherMappingProfile : Profile
    {
        public TeacherMappingProfile()
        {
            CreateMap<AddTeacherDTO, DomainLayer.Entities.Teacher>()

                .ForMember(dest => dest.SubjectExpertise, opt => opt.MapFrom(src => src.AddTeacherInfoDTO.SubjectExpertise))
                .ForMember(dest => dest.bio, opt => opt.MapFrom(src => src.AddTeacherInfoDTO.bio))
                .ForMember
                (dest => dest.EmploymentDetails, opt => opt.MapFrom
                    (
                        src => new EmploymentDetail
                        {
                            ContractType = src.DetailsDTO.ContractType,
                            Salary = src.DetailsDTO.Salary,
                        }
                    )
                )
                .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(src => new DomainLayer.Entities.User
                {
                    PersonInfo = new Person
                    {
                        NationalNO = src.InfoDTO.NationalNO,
                        FirstName = src.InfoDTO.FirstName,
                        SecondName = src.InfoDTO.SecondName,
                        ThirdName = src.InfoDTO.ThirdName,
                        LastName = src.InfoDTO.LastName,
                        DateOfBirth = src.InfoDTO.DateOfBirth,
                        Gender = src.InfoDTO.Gender,
                        NationalityID = (int)src.InfoDTO.Nationality,
                        ImagePath = src.InfoDTO.ImagePath
                    },
                    PasswordHash = src.UserInfoDTO.Password,
                    Email = src.AddTeacherInfoDTO.Email,
                    PhoneNumber = src.UserInfoDTO.PhoneNumber
                }));
        }
    }
}
