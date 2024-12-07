using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.Classes.Queries.GetClassesByName
{
    public class GetClassByNameQueryHandler : IRequestHandler<GetClassByNameQuery, Response<ClassQueryDTO>>
    {
        #region Fields
        private readonly IClassServices _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion

        #region Constructure(s)
        public GetClassByNameQueryHandler(IClassServices classServices, IMapper mapper, ResponseHandler responseHandler)
        {
            _mapper = mapper;
            _services = classServices;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<ClassQueryDTO>> Handle(GetClassByNameQuery request, CancellationToken cancellationToken)
        {
            //  Fetch the class from the service
            var CDTO = await _services.GetByName(request.ClassName).SingleOrDefaultAsync();

            return CDTO == null ?
                _responseHandler.NotFound<ClassQueryDTO>($"Class with Name {request.ClassName} is not found!") : _responseHandler.Success(_mapper.Map<ClassQueryDTO>(CDTO));
        }
        #endregion
    }

}
