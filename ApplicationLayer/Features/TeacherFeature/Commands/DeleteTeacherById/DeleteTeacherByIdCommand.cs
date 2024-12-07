using ApplicationLayer.Models;
using MediatR;

namespace SchoolApp.Application.Features.TeacherFeatrue.Commands.DeleteTeacherCommand
{

    public class DeleteTeacherByIdCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteTeacherByIdCommand(int id)
        {
            Id = id;
        }
    }
}
