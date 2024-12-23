﻿namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Queries.GetUserRoles;

//public class GetUserRolesByUserIdQueryHandler : ResponseHandler,
//    IRequestHandler<GetUserRolesByUserIdQuery, Response<UserRolesQueryDTO>>
//{
//    #region Field(s)
//    private readonly IAuthorizationService _authorizationService;
//    private readonly IUserService _userService;
//    private readonly IMapper _mapper;
//    #endregion

//    #region Field(s)
//    public GetUserRolesByUserIdQueryHandler(IAuthorizationService authorizationService, IUserService userService, IMapper mapper, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
//    {
//        _authorizationService = authorizationService;
//        _userService = userService;
//        _mapper = mapper;
//    }
//    #endregion


//    #region Handler
//    public async Task<Response<UserRolesQueryDTO>> Handle(GetUserRolesByUserIdQuery request, CancellationToken cancellationToken)
//    {
//        var userWithRoles = await _userService
//            .GetUserById(request.UserId)
//            .Select(u => new UserRolesQueryDTO
//            {
//                UserId = u.Id,
//                UserRoles = u.UserRoles.Select(r => new UserRolesQueryDTO.MiniRoleData { RoleId = r.RoleId, Name = r.Role.Name!}).ToList()
//            })
//            .FirstOrDefaultAsync();


//        if (userWithRoles == null) return NotFound<UserRolesQueryDTO>("No user found with the provided id");

//        return Success(userWithRoles);
//    }
//    #endregion
//}
