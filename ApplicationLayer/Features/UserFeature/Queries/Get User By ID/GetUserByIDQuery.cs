using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.User.Queries
{
    public class GetUserByIDQuery : IRequest<Response<UserQueryDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Constructure(s)
        public GetUserByIDQuery(int Id) => ID = Id;

        #endregion
    }
}
