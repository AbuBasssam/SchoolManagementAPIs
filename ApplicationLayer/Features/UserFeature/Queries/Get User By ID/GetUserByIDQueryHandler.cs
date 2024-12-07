using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.User.Queries
{
    public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, Response<UserQueryDTO>>
    {

        #region Field(s)
        private readonly IUserService _services;
        //private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetUserByIDQueryHandler(IUserService UserServices, ResponseHandler responseHandler)//, IMapper mapper
        {
            // _mapper = mapper;
            _services = UserServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<UserQueryDTO>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the list of User from the service

            var User = await _services.GetById(request.ID)
                .Select(UserQueryHelper.UserDTOMap())
                .FirstOrDefaultAsync(cancellationToken);


            return User == null ?
               _responseHandler.NotFound<UserQueryDTO>($"User with ID {request.ID} is not found!") : _responseHandler.Success(User);

        }

        #endregion
    }
}
