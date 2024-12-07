using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalConditionByID
{
    public class MedicalConditionsByIDQueryHandler : IRequestHandler<GetMedicalConditionsByIDQuery, Response<MedicalContionQueryDTO>>
    {

        #region Field(s)
        private readonly IMedicalConditioService _Services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandeler;

        #endregion

        #region Constructure(s)
        public MedicalConditionsByIDQueryHandler(IMedicalConditioService services, IMapper mapper, ResponseHandler responseHandeler)
        {
            _Services = services;
            _mapper = mapper;
            _responseHandeler = responseHandeler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<MedicalContionQueryDTO>> Handle(GetMedicalConditionsByIDQuery request, CancellationToken cancellationToken)
        {
            var MC = await _Services.GetById(request.ID).SingleOrDefaultAsync();

            return MC == null ?
                _responseHandeler.NotFound<MedicalContionQueryDTO>($"No medical condition with ID {request.ID} !") :
                _responseHandeler.Success(_mapper.Map<MedicalContionQueryDTO>(MC));

        }
        #endregion
    }



}
