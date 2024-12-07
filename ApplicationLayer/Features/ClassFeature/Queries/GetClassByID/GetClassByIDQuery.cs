using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Classes.Queries.GetClassByID
{
    public class GetClassByIDQuery : IRequest<Response<ClassQueryDTO>>
    {
        #region Field(s)

        public int ID { get; set; }

        #endregion

        #region Constructure(s)
        public GetClassByIDQuery(int Id) => ID = Id;

        #endregion

    }
}
