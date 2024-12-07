using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.SectionFeature.Commands.UpdateSection
{
    public class UpdateSectionScheduleCommand : IRequest<Response<SectionQueryDTO>>
    {
        #region Field(s)
        public UpdateSectionCommandDTO DTO { get; set; }

        #endregion

        #region Constructure(s)
        public UpdateSectionScheduleCommand(UpdateSectionCommandDTO dto)
        {
            DTO = dto;
        }

        #endregion



    }




}