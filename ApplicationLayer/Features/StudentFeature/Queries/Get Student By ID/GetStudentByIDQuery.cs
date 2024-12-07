using ApplicationLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Student.Queries
{
    public class GetStudentByIDQuery : IRequest<Response<StudentQueryDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Constructure(s)
        public GetStudentByIDQuery(int Id)
        {
            ID = Id;
        }

        #endregion
    }
}
