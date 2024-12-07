using ApplicationLayer.Features.User.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Admin.Queries.Get_Admin_By_Admin_Number
{
    public class GetAdminByUserNameNameQuery : IRequest<Response<UserQueryDTO>>
    {
        #region Field(s)
        public string UserName { get; set; }

        #endregion

        #region Constructure(s)
        public GetAdminByUserNameNameQuery(string userName) => UserName = userName;

        #endregion
    }
}
