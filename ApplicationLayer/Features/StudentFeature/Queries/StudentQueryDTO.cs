using ApplicationLayer.Models;
using DomainLayer.Enums;

namespace ApplicationLayer.Features.Student.Queries
{
    public class StudentQueryDTO
    {

        public AddUserInfoDTO Info { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public enLevel GradeLevel { get; set; }


        public StudentQueryDTO(AddUserInfoDTO info, DateTime enrollmentDate, enLevel gradeLevel)
        {
            Info = info;
            EnrollmentDate = enrollmentDate;
            GradeLevel = gradeLevel;
        }

    }
}