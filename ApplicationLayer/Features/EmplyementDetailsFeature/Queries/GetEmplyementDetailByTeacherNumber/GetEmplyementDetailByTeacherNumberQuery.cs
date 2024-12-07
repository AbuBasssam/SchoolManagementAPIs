using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.EmplyementDetails.Queries.GetEmplyementDetailByTeacherNumber
{
    public class GetEmplyementDetailByTeacherNumberQuery : IRequest<Response<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        public string TeacherNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetEmplyementDetailByTeacherNumberQuery(string teacherNumber) => TeacherNumber = teacherNumber;

        #endregion
    }
}