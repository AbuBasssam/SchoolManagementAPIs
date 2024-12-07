using ApplicationLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Teacher.Queries.Get_Teacher_By_Teacher_Number
{
    public class GetTeacherByTeacherNumberQuery : IRequest<Response<TeacherQueryDTO>>
    {
        #region Field(s)
        public string TeacherNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetTeacherByTeacherNumberQuery(string teacherNumber)
        {
            TeacherNumber = teacherNumber;
        }

        #endregion
    }
}
