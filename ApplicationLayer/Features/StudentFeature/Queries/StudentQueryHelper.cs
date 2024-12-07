using ApplicationLayer.Models;
using System.Linq.Expressions;

namespace ApplicationLayer.Features.Student.Queries
{
    public static class StudentQueryHelper
    {
        public static Expression<Func<DomainLayer.Entities.Student, StudentQueryDTO>> StudentDTOMap()
       
           =>s => new StudentQueryDTO
           (
                new AddUserInfoDTO
                        (
                           s.UserInfo.PersonInfo.NationalNO,
                           s.UserInfo.UserName!,
                           s.UserInfo.PersonInfo.FullName,
                           s.UserInfo.PersonInfo.DateOfBirth,
                           s.UserInfo.PersonInfo.Nationality.NationalityName,
                           s.UserInfo.PersonInfo.Gender,
                           s.UserInfo.PersonInfo.ImagePath
                        ),
                           s.EnrollmentDate,
                           s.GradeLevel
                                   
           );
        
    }
}
