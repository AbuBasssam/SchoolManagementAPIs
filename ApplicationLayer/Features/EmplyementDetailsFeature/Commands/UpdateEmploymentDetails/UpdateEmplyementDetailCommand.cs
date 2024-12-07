using ApplicationLayer.Features.EmplyementDetails.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails
{

    public class UpdateEmplyementDetailCommand : IRequest<Response<EmplyementDetailQueryDTO>>
    {
        #region Field(s)
        public UpdateEmployementDetailsCommandDTO DTO { get; set; }
        public string TeacherNumber { get; set; }


        #endregion

        #region Constructure(s)
        public UpdateEmplyementDetailCommand(UpdateEmployementDetailsCommandDTO dTO, string teacherNumber)
        {
            DTO = dTO;
            TeacherNumber = teacherNumber;
        }
        #endregion
    }
}