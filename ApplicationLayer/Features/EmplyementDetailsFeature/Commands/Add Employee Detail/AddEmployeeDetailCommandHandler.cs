namespace ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails
{
    /*public class AddEmployeeDetailCommandHandler : IRequestHandler<AddEmployeeDetailCommand, Response<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        private readonly IEmploymentDetailsService _service;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        #endregion

        #region Constructure(s)
        public AddEmployeeDetailCommandHandler(ResponseHandler responseHandler, IEmploymentDetailsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _responseHandler = responseHandler;

        }

        #endregion

        #region Handler(s)
        public async Task<Response<EmplyementDetailQueryDTO>> Handle(AddEmployeeDetailCommand request, CancellationToken cancellationToken)
        {
            var IsAdded = await _service.AddAsync(request.DTO);


            return IsAdded ? _responseHandler.Created(_mapper.Map<EmplyementDetailQueryDTO>(request.DTO)) :
                             _responseHandler.BadRequest<EmplyementDetailQueryDTO>("Add filed");
        }
        #endregion
    }*/
}
