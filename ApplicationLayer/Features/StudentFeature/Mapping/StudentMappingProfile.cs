using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Features.Students.Commands.AddNewStudent;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Students.Mapping
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            StudentToQueryDTO();
            AddStudentCommandToStudent();
        }

        private void AddStudentCommandToStudent()
        {
            CreateMap<AddStudentDTO, DomainLayer.Entities.Student>()
                            .ForMember
                            (dest => dest.UserInfo, opt => opt.MapFrom
                                (
                                    src => new DomainLayer.Entities.User
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
                                        PhoneNumber = src.UserInfoDTO.PhoneNumber
                                    }
                                )
                            );
        }

        private void StudentToQueryDTO()
        {
            CreateMap<DomainLayer.Entities.Student, StudentQueryDTO>()
                .ConstructUsing(src => new StudentQueryDTO(
                    new AddUserInfoDTO
                    (
                        src.UserInfo.PersonInfo.NationalNO,
                        src.UserInfo.UserName!,
                        src.UserInfo.PersonInfo.FullName,
                        src.UserInfo.PersonInfo.DateOfBirth,
                        src.UserInfo.PersonInfo.Nationality.NationalityName,
                        src.UserInfo.PersonInfo.Gender,
                        src.UserInfo.PersonInfo.ImagePath),
                        src.EnrollmentDate,
                        src.GradeLevel
                    )
                );
        }
    }
}
