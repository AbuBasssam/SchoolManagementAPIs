using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.SectionFeature.Commands
{
    public class AddSectionCommand : IRequest<Response<SectionQueryDTO>>
    {
        #region Field(s)
        public AddSectionCommandDTO DTO { get; set; }

        #endregion


        #region Constructure(s)
        public AddSectionCommand(AddSectionCommandDTO dto)
        {
            DTO = dto;
        }

        #endregion



    }
}
