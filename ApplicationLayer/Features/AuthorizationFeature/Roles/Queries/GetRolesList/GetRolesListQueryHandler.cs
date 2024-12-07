using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRolesList;

public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, Response<List<RoleQueryDTO>>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    private readonly ResponseHandler _responseHandler;
    #endregion

    #region Constructure(s)
    public GetRolesListQueryHandler(IAuthorizationService authorizationService, IMapper mapper, ResponseHandler responseHandler)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
        _responseHandler = responseHandler;

    }
    #endregion


    #region Handler
    public async Task<Response<List<RoleQueryDTO>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _authorizationService.GetRolesList()
                                               .ProjectTo<RoleQueryDTO>(_mapper.ConfigurationProvider)
                                               .ToListAsync();

        return _responseHandler.Success(roles);
    }
    #endregion
}
