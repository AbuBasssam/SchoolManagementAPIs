using ApplicationLayer.Models;
using ApplicationLayer.Services;
using MediatR;

namespace ApplicationLayer.Features.SectionFeature.Commands.CloseSection
{
    public class DeleteSectionCommand : IRequest<Response<bool>>
    {
        #region Field(s)
        public string SectionNumber { get; set; }

        #endregion

        #region Constructure(s)
        public DeleteSectionCommand(string sectionNumber)
        {
            SectionNumber = sectionNumber;

        }

        #endregion

    }
    public class CloseSectionCommandHander : IRequestHandler<DeleteSectionCommand, Response<bool>>
    {
        #region Field(s)
        private readonly ResponseHandler _responseHandler;
        private readonly ISectionService _SectionService;

        #endregion

        #region Constructure(s)
        public CloseSectionCommandHander(ResponseHandler responseHandler, ISectionService sectionService)
        {
            _responseHandler = responseHandler;
            _SectionService = sectionService;

        }

        public async Task<Response<bool>> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var IsClosed = await _SectionService.CloseAsync(request.SectionNumber);

            return IsClosed ? _responseHandler.Success(IsClosed) : _responseHandler.BadRequest<bool>("Closed filed");


        }

        #endregion



    }




}