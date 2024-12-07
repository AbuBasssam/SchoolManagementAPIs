using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Classes.Queries.GetClassByID
{
    public class GetClassByIDQueryHandler : IRequestHandler<GetClassByIDQuery, Response<ClassQueryDTO>>
    {
        #region Fields
        private readonly IClassServices _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructure(s)
        public GetClassByIDQueryHandler(IClassServices classServices, IMapper mapper, ResponseHandler responseHandler)
        {
            _mapper = mapper;
            _services = classServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<ClassQueryDTO>> Handle(GetClassByIDQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the class from the service

            var Class = await _services.GetById(request.ID).FirstOrDefaultAsync(cancellationToken);

            return Class == null ?
               _responseHandler.NotFound<ClassQueryDTO>($"Class with ID {request.ID} is not found!") : _responseHandler.Success(_mapper.Map<ClassQueryDTO>(Class));

        }

        #endregion
    }

}
