using ApplicationLayer.Features.User.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Admin.Queries
{
    public class GetAdminByIDQuery : IRequest<Response<UserQueryDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Constructure(s)
        public GetAdminByIDQuery(int Id) => ID = Id;

        #endregion
    }
}
