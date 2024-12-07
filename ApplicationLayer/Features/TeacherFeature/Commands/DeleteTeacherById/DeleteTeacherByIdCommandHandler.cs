using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Application.Features.TeacherFeatrue.Commands.DeleteTeacherCommand;

public class DeleteTeacherByIdCommandHandler : IRequestHandler<DeleteTeacherByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly ITeacherService _service;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructor(s)
    public DeleteTeacherByIdCommandHandler(ITeacherService service, IMapper mapper, ResponseHandler responseHandler)
    {
        _service = service;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(DeleteTeacherByIdCommand request, CancellationToken cancellationToken)
    {
        var Teacher = await _service.GetById(request.Id).FirstOrDefaultAsync();
        if (Teacher == null) return _responseHandler.NotFound<string>($"No Teacher found with Id={request.Id}");

        bool isDeleted = await _service.DeleteAsync(Teacher);

        return isDeleted ? _responseHandler.Deleted<string>("Deleted successfully") : _responseHandler.BadRequest<string>("Failed to delete");
    }
    #endregion
}
