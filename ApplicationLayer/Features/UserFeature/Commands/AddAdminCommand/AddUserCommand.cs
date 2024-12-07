using ApplicationLayer.Features.User.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.UserFeature.Commands.AddAdminCommand
{
    public class AddUserCommand : IRequest<Response<UserQueryDTO>>
    {
        #region Field(s)
        public AddAdminDTO DTO { get; set; }
        #endregion

        #region Constructure(s)
        public AddUserCommand(AddAdminDTO dto)
        {
            DTO = dto;

        }
        #endregion

    }


}
