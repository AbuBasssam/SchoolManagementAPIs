using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Teacher.Queries
{
    public static class TeacherQueryHelper
    {
        public static Expression<Func<DomainLayer.Entities.Teacher, TeacherQueryDTO>> TeacherDTOMap()
            => t => new TeacherQueryDTO
            (
                new AddUserInfoDTO
                (
                    t.UserInfo.PersonInfo.NationalNO,
                    t.UserInfo.UserName!,
                    t.UserInfo.PersonInfo.FullName,
                    t.UserInfo.PersonInfo.DateOfBirth,
                    t.UserInfo.PersonInfo.Nationality.NationalityName,
                    t.UserInfo.PersonInfo.Gender,
                    t.UserInfo.PersonInfo.ImagePath
                ),
                    t.SubjectExpertise,
                    t.bio,
                    t.EmploymentDetails.ContractType,
                    t.EmploymentDetails.Salary
            );


    }
}
