using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainLayer.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.UpdateRoleById;

public class UpdateRoleByIdCommandHandler : IRequestHandler<UpdateRoleByIdCommand, Response<RoleQueryDTO>>
{

    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructor(s)
    public UpdateRoleByIdCommandHandler(IAuthorizationService authorizationService, IMapper mapper, ResponseHandler responseHandler)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }
    #endregion


    #region Method(s)
    public async Task<Response<RoleQueryDTO>> Handle(UpdateRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var existingRole = await _authorizationService.GetRoleById(request.Id)
                                                      .ProjectTo<Role>(_mapper.ConfigurationProvider)
                                                      .FirstOrDefaultAsync();

        if (existingRole == null) return _responseHandler.NotFound<RoleQueryDTO>("Cannot update the role because there is no role with the provided id");

        var mappedRole = _mapper.Map(request, existingRole);

        var result = await _authorizationService.UpdateRoleAsync(mappedRole);

        if (result.Succeeded)
            return _responseHandler.Success(_mapper.Map<RoleQueryDTO>(mappedRole));
        else return _responseHandler.BadRequest<RoleQueryDTO>(result.Errors.ToString());
    }
    #endregion
}
