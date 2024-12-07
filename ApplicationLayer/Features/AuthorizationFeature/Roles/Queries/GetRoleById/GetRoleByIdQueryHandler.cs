using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRoleById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Response<RoleQueryDTO>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Field(s)
    public GetRoleByIdQueryHandler(IAuthorizationService authorizationService, IMapper mapper, ResponseHandler responseHandler)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }
    #endregion


    #region Handler
    public async Task<Response<RoleQueryDTO>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _authorizationService.GetRoleById(request.Id)
                                              .ProjectTo<RoleQueryDTO>(_mapper.ConfigurationProvider)
                                              .FirstOrDefaultAsync();

        if (role == null) return _responseHandler.NotFound<RoleQueryDTO>("No role found with the provided id");

        else return _responseHandler.Success(role);
    }
    #endregion
}
