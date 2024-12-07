using ApplicationLayer.Features.EmplyementDetails.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails
{
    public class UpdateEmplyementDetailCommandHandler : IRequestHandler<UpdateEmplyementDetailCommand, Response<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        private readonly IEmploymentDetailsService _Service;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion

        #region Constructure(s)
        public UpdateEmplyementDetailCommandHandler(ResponseHandler responseHandler, IEmploymentDetailsService service, IMapper mapper)
        {
            _Service = service;
            _mapper = mapper;
            _responseHandler = responseHandler;

        }


        #endregion

        #region Handler(s)
        public async Task<Response<EmplyementDetailQueryDTO>> Handle(UpdateEmplyementDetailCommand request, CancellationToken cancellationToken)
        {
            var IsUpdateed = await _Service.UpdateAsync(request.TeacherNumber, request.DTO);

            if (IsUpdateed)
            {
                var Details = await _Service.GetByTeacherNumber(request.TeacherNumber).SingleOrDefaultAsync();
                return _responseHandler.Success(_mapper.Map<EmplyementDetailQueryDTO>(Details));
            }

            return _responseHandler.BadRequest<EmplyementDetailQueryDTO>("Update filed");
        }

        #endregion
    }
}
