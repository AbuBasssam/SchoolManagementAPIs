using ApplicationLayer.Comman;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Schedule.Queries.GetSchedulesPage
{
    public class GetSchedulesPageQuery : IRequest<PaginatedResult<ScheduleDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetSchedulesPageQuery(int pageNumber)
        {
            PageNumber = pageNumber;
        }

        #endregion
    }
}
