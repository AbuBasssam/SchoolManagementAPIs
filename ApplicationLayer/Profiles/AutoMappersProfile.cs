using ApplicationLayer.Features.Students.Helper;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Profiles
{
    public class AutoMappersProfile : Profile
    {
        public AutoMappersProfile()
        {

            // CreateMap<Class, ClassQueryDTO>().ReverseMap();
            //CreateMap<MedicalCondition, MedicalContionQueryDTO>().ReverseMap();

            //CreateMap<FilterClassesDTO, FilterClasses>().ReverseMap();
            //CreateMap<CourseQueryDTO, Course>().ReverseMap();
            //CreateMap<UpdateCourseCommandDTO, Course>().ReverseMap();

            //CreateMap<SectionQueryDTO, Section>().ReverseMap();
            //CreateMap<EmploymentDetail, EmplyementDetailQueryDTO>().ReverseMap();
            //CreateMap<AddEmplyementDetailCommandDTO, EmplyementDetailQueryDTO>().ReverseMap();
            //CreateMap<EmploymentDetail, AddEmplyementDetailCommandDTO>().ReverseMap();
            //CreateMap<EmploymentDetail, UpdateEmployementDetailsCommandDTO>().ReverseMap();



            /*CreateMap<AddSectionCommandDTO, Section>()
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
                        .ForMember(dest => dest.CourseID, opt => opt.Ignore()) // Assign CourseID if it’s handled differently
                        .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignored because DTO doesn’t contain ID
                        .ForMember(dest => dest.OpenAt, opt => opt.Ignore()) // Set separately if required
                        .ForMember(dest => dest.CloseAt, opt => opt.Ignore()) // Set separately if required
                        .ForMember(dest => dest.TeacherID, opt => opt.Ignore()) // Handle teacher assignment separately
                        .ForMember(dest => dest.ScheduleID, opt => opt.Ignore()) // Handle schedule assignment separately
                        .ForMember(dest => dest.Schedule, opt => opt.Ignore()) // Ignored if not needed
                        .ForMember(dest => dest.Teacher, opt => opt.Ignore()) // Ignored if not part of AddSectionCommandDTO
                        .ForMember(dest => dest.Students, opt => opt.Ignore()) // Ignored since not part of the DTO
                        .ForMember(dest => dest.Attendances, opt => opt.Ignore()); // Ignored since not part of the DTO
                        
             */



            /*CreateMap<Student, StudentQueryDTO>()
            .ConstructUsing
            (
                src => new StudentQueryDTO
                (
                    new UserInfoDTO
                    (
                        src.UserInfo.PersonInfo.NationalNO,
                        src.UserInfo.UserName!,
                        src.UserInfo.PersonInfo.FullName,
                        src.UserInfo.PersonInfo.DateOfBirth,
                        src.UserInfo.PersonInfo.Nationality.NationalityName,
                        src.UserInfo.PersonInfo.Gender,
                        src.UserInfo.PersonInfo.ImagePath

                    ),
                    src.EnrollmentDate,

                    src.GradeLevel


                )
            );
            */

            /*CreateMap<AddStudentDTO, Student>()
           .ForMember
            (
                dest => dest.UserInfo, opt => opt.MapFrom
                (
                    src => new ApplicationUser
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
                        PhoneNumber = src.UserInfoDTO.PhoneNumber,

                    }

                )
            );
            */


            CreateMap<UpdateInfoDTO, Person>()
                        .ForMember(dest => dest.NationalityID, opt => opt.MapFrom(src => (int)src.Nationality))
                        .ForMember(dest => dest.Nationality, opt => opt.Ignore());




            /* CreateMap<AddTeacherDTO, Teacher>()
            .ForMember
            (
                 dest => dest.SubjectExpertise, opt => opt.MapFrom
                 (
                     src => src.AddTeacherInfoDTO.SubjectExpertise

                 )
            )    //SubjectExpertise

            .ForMember
            (
                 dest => dest.bio, opt => opt.MapFrom
                 (
                     src => src.AddTeacherInfoDTO.bio
                 )
            )    //bio

            .ForMember    //Employement Details
           (
             dest => dest.EmploymentDetails, opt => opt.MapFrom
             (
                 src => new EmploymentDetail
                 {
                     ContractType = src.DetailsDTO.ContractType,
                     Salary = src.DetailsDTO.Salary,
                 }
             )
           )
           .ForMember    //User & Person Info 
             (
                 dest => dest.UserInfo, opt => opt.MapFrom
                 (
                     src => new ApplicationUser
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
                         PhoneNumber = src.UserInfoDTO.PhoneNumber,

                     }

                 )
             );*/


        }
    }

}


