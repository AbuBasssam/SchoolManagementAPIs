using ApplicationLayer.Comman;
using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features
{
    public class GetStudentsPageQuery : IRequest<PaginatedResult<StudentQueryDTO>>
    {
        #region Field(s)
        public int PageNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetStudentsPageQuery(int pageNumber)
        {
            PageNumber = pageNumber;
        }

        #endregion
    }
}
