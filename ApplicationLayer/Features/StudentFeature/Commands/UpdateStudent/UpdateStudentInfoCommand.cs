using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentInfoCommand : IRequest<Response<StudentQueryDTO>>
    {
        #region Field(s)

        public UpdateInfoDTO DTO { get; set; }
        public string StudentNumber { get; set; }

        #endregion

        #region Constructure(s)

        public UpdateStudentInfoCommand(UpdateInfoDTO dto, string studentNumber)
        {
            DTO = dto;
            StudentNumber = studentNumber;
        }

        #endregion
    }
}
