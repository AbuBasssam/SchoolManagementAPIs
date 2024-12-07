using ApplicationLayer.Features.UserFeature.Commands.AddAdminCommand;
using AutoMapper;

namespace ApplicationLayer.Features.UserFeature.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            AddUserCommandToUser();
            //AddStudentCommandToStudent();
        }

        private void AddUserCommandToUser()
        {
            CreateMap<AddAdminDTO, DomainLayer.Entities.User>()
                            .ForMember
                            (dest => dest.PersonInfo, opt => opt.MapFrom
                                (
                                    src => new DomainLayer.Entities.Person
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
                                    }
                                )
                            )
                            .ForMember
                            (
                                        dest => dest.PasswordHash, // Map the PasswordHash property
                                        opt => opt.MapFrom(src => src.UserInfoDTO.Password)
                            )
                            .ForMember
                            (
                                dest => dest.PhoneNumber, // Map the PhoneNumber property
                                opt => opt.MapFrom(src => src.UserInfoDTO.PhoneNumber)
                            )
                            .ForMember
                            (
                                dest => dest.Email, // Map the Email property
                                opt => opt.MapFrom(src => src.Email)
                            );

        }
    }
}
