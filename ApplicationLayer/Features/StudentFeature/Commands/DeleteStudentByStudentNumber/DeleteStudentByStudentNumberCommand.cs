using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.StudentFeature.Commands.DeleteStudentByStudentNumber;

public class DeleteStudentByStudentNumberCommand : IRequest<Response<string>>
{
    public string StudentNumber { get; set; }
    public DeleteStudentByStudentNumberCommand(string studentNumber)
    {
        StudentNumber = studentNumber;
    }
}
