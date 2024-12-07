
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.AddRole;

public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Response<string>>
{
    #region Field(s)
    private readonly IAuthorizationService _roleService;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructor(s)
    public AddRoleCommandHandler(IAuthorizationService roleService, IMapper mapper, ResponseHandler responseHandler)
    {
        _roleService = roleService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        //throw new NotImplementedException();
        var result = await _roleService.AddRoleAsync(_mapper.Map<Role>(request));
        if (result.Succeeded) return _responseHandler.Success("Added successfully");
        else return _responseHandler.BadRequest<string>("Failed to add the role");
    }
    #endregion
}
