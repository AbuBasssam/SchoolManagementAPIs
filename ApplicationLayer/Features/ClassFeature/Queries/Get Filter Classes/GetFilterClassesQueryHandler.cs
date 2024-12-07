using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Features.Classes.Queries.Get_Filter_Classes
{
    public class GetFilterClassesQueryHandler : IRequestHandler<GetFilterClassesQuery, Models.Response<IList<ClassQueryDTO>>>
    {
        #region Field(s)
        private readonly IClassServices _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion

        #region Constructure(s)
        public GetFilterClassesQueryHandler(IClassServices services, IMapper mapper, ResponseHandler responseHandler)
        {
            _services = services;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        #endregion

        #region Handler(s)
        public async Task<Response<IList<ClassQueryDTO>>> Handle(GetFilterClassesQuery request, CancellationToken cancellationToken)
        {
            var filter = _mapper.Map<FilterClasses>(request.Filter);
            var CDTO = await _services.GetFilterClasses(filter);

            return CDTO == null || !CDTO.Any() ?
                          _responseHandler.NotFound<IList<ClassQueryDTO>>($"No classes found!") : _responseHandler.Success(_mapper.Map<IList<ClassQueryDTO>>(CDTO));

        }
        #endregion
    }

}
