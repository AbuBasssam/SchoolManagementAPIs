using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Application.Features.StudentFeatrue.Commands.DeleteStudentCommand;

public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly IStudentService _service;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructor(s)
    public DeleteStudentByIdCommandHandler(IStudentService service, IMapper mapper, ResponseHandler responseHandler)
    {
        _service = service;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(DeleteStudentByIdCommand request, CancellationToken cancellationToken)
    {
        var student = await _service.GetById(request.Id).FirstOrDefaultAsync();
        if (student == null) return _responseHandler.NotFound<string>($"No student found with Id={request.Id}");

        bool isDeleted = await _service.DeleteAsync(student);

        return isDeleted ? _responseHandler.Deleted<string>("Deleted successfully") : _responseHandler.BadRequest<string>("Failed to delete");
    }
    #endregion
}
