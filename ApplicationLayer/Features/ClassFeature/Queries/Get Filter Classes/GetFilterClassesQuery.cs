using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Classes.Queries.Get_Filter_Classes
{

    public class GetFilterClassesQuery : IRequest<Response<IList<ClassQueryDTO>>>
    {
        #region Field(s)
        public FilterClassesDTO Filter;

        #endregion

        #region Consturcture(s)
        public GetFilterClassesQuery(FilterClassesDTO filter) => Filter = filter;

        #endregion

    }

}
