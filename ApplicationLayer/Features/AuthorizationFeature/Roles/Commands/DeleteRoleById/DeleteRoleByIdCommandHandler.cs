using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.DeleteRoleById;

public class DeleteRoleByIdCommandHandler : IRequestHandler<DeleteRoleByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructor(s)
    public DeleteRoleByIdCommandHandler(IAuthorizationService authorizationService, IMapper mapper, ResponseHandler responseHandler)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
        _responseHandler = responseHandler;

    }
    #endregion


    #region Method(s)
    public async Task<Response<string>> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var existingRole = await _authorizationService.GetRoleById(request.Id).FirstOrDefaultAsync();//.ProjectTo<Role>(_mapper.ConfigurationProvider)

        if (existingRole == null) return _responseHandler.NotFound<string>("Cannot delete the role because it was not found");

        try
        {
            var result = await _authorizationService.DeleteRoleAsync(existingRole);

            if (result.Succeeded) return _responseHandler.Success("Deleted successfully");

            else return _responseHandler.BadRequest<string>(result.Errors.ToString());
        }
        catch (Exception)
        {
            return _responseHandler.NotFound<string>("Cannot delete the role because the role has users linked to it");
        }
    }
    #endregion
}
