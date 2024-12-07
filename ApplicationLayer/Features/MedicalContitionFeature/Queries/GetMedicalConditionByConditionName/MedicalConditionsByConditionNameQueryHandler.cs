using ApplicationLayer.Interfaces.Persentation_Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ApplicationLayer.Models;
using ApplicationLayer.Features.Classes.Queries;
using DomainLayer.Entities;


namespace ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalConditionByConditionName
{
    public class MedicalConditionsByConditionNameQueryHandler : IRequestHandler<GetMedicalConditionsByConditionNameQuery, Response<MedicalContionQueryDTO>>
    {
        #region Field(s)
        private readonly IMedicalConditioService _services;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion
        
        #region Constructure(s)
        public MedicalConditionsByConditionNameQueryHandler(IMedicalConditioService services, IMapper mapper, ResponseHandler responseHandler)
        {
            _services = services;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        #endregion

        #region Handler(s)
        public async Task<Response<MedicalContionQueryDTO>> Handle(GetMedicalConditionsByConditionNameQuery request, CancellationToken cancellationToken)
        {
            var DTO = await _services.GetByName(request.ConditionName).SingleOrDefaultAsync();

            return DTO == null ?
               _responseHandler.NotFound<MedicalContionQueryDTO>($"Medical Condition with Name {request.ConditionName} is not found!") :
               _responseHandler.Success(_mapper.Map<MedicalContionQueryDTO>(DTO)); ;

        } 
        #endregion
    }
}
