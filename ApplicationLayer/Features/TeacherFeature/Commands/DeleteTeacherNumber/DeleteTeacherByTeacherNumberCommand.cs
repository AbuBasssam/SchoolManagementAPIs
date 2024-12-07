using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.TeacherFeature.Commands.DeleteTeacherByTeacherNumber;

public class DeleteTeacherByTeacherNumberCommand : IRequest<Response<string>>
{
    public string TeacherNumber { get; set; }
    public DeleteTeacherByTeacherNumberCommand(string teacherNumber)
    {
        TeacherNumber = teacherNumber;
    }
}
