using ApplicationLayer.Features.Student.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Students.Commands.AddNewStudent
{
    public class AddStudentCommand : IRequest<Response<StudentQueryDTO>>
    {
        #region Field(s)
        public AddStudentDTO DTO { get; set; }
        #endregion

        #region Constructure(s)
        public AddStudentCommand(AddStudentDTO dto)
        {
            DTO = dto;
        }
        #endregion

    }


}
