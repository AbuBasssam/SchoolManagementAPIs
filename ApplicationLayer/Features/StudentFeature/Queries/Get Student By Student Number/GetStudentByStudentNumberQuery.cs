using ApplicationLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Student.Queries.Get_Student_By_Student_Number
{
    public class GetStudentByStudentNumberQuery : IRequest<Response<StudentQueryDTO>>
    {
        #region Field(s)
        public string StudentNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetStudentByStudentNumberQuery(string studentNumber)
        {
            StudentNumber = studentNumber;
        }

        #endregion
    }
}
