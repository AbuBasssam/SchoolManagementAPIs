using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.User.Queries.Get_User_By_User_Number
{
    public class GetAdminByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, Response<UserQueryDTO>>
    {

        #region Field(s)
        private readonly IUserService _services;
        //private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetAdminByUserNameQueryHandler(IUserService UserServices, ResponseHandler responseHandler)//, IMapper mapper
        {
            //_mapper = mapper;
            _services = UserServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<UserQueryDTO>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the list of User from the service
            var User = await _services.GetByUserName(request.UserName)
                .Select(UserQueryHelper.UserDTOMap())
                .FirstOrDefaultAsync(cancellationToken);


            return User == null ?
               _responseHandler.NotFound<UserQueryDTO>($"User with Number {request.UserName} is not found!") : _responseHandler.Success(User);

        }
        #endregion
    }
}
