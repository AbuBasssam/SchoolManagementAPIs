using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Classes.Queries.GetClassesByName
{
    public class GetClassByNameQuery : IRequest<Response<ClassQueryDTO>>
    {
        #region Field(s)
        public string ClassName { get; set; }

        #endregion

        #region Constructure(s)
        public GetClassByNameQuery(string className) => ClassName = className;

        #endregion
    }
}
