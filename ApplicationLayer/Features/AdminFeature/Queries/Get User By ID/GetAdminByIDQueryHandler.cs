using ApplicationLayer.Features.User.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Admin.Queries
{
    public class GetAdminByIDQueryHandler : IRequestHandler<GetAdminByIDQuery, Response<UserQueryDTO>>
    {

        #region Field(s)
        private readonly IUserService _services;
        //private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetAdminByIDQueryHandler(IUserService AdminServices, ResponseHandler responseHandler)//, IMapper mapper
        {
            // _mapper = mapper;
            _services = AdminServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<UserQueryDTO>> Handle(GetAdminByIDQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the list of Admin from the service

            var Admin = await _services.GetById(request.ID)
                .Select(UserQueryHelper.UserDTOMap())
                .FirstOrDefaultAsync(cancellationToken);


            return Admin == null ?
               _responseHandler.NotFound<UserQueryDTO>($"Admin with ID {request.ID} is not found!") : _responseHandler.Success(Admin);

        }

        #endregion
    }
}
