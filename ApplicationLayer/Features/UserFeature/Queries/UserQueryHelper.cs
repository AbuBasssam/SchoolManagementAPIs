using ApplicationLayer.Models;
using System.Linq.Expressions;

namespace ApplicationLayer.Features.User.Queries
{
    public static class UserQueryHelper
    {
        public static Expression<Func<DomainLayer.Entities.User, UserQueryDTO>> UserDTOMap()

           => s => new UserQueryDTO
           (
                new AddUserInfoDTO
                        (
                           s.PersonInfo.NationalNO,
                           s.UserName!,
                           s.PersonInfo.FullName,
                           s.PersonInfo.DateOfBirth,
                           s.PersonInfo.Nationality.NationalityName,
                           s.PersonInfo.Gender,
                           s.PersonInfo.ImagePath
                        )



           );

    }
}
