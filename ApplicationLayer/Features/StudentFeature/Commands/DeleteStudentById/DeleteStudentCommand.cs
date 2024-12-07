using ApplicationLayer.Models;
using MediatR;

namespace SchoolApp.Application.Features.StudentFeatrue.Commands.DeleteStudentCommand
{

    public class DeleteStudentByIdCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteStudentByIdCommand(int id)
        {
            Id = id;
        }
    }
}
