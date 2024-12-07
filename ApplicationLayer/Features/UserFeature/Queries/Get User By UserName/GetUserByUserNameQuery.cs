using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.User.Queries.Get_User_By_User_Number
{
    public class GetUserByUserNameQuery : IRequest<Response<UserQueryDTO>>
    {
        #region Field(s)
        public string UserName { get; set; }

        #endregion

        #region Constructure(s)
        public GetUserByUserNameQuery(string UserName) => this.UserName = UserName;

        #endregion
    }
}
