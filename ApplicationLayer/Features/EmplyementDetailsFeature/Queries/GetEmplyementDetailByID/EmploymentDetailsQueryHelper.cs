using System.Linq.Expressions;

namespace ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByID
{
    public static class EmploymentDetailsQueryHelper
    {
        public static Expression<Func<DomainLayer.Entities.EmploymentDetail, EmplyementDetailQueryDTO>> EmploymentDetailsDTOMap()

           =>
            se => new EmplyementDetailQueryDTO
           (
                           se.Teacher.UserInfo.UserName!,
                           se.Teacher.UserInfo.PersonInfo.FullName,
                           se.HiringDate,
                           se.ContractType,
                           se.Salary

           );
    }
}