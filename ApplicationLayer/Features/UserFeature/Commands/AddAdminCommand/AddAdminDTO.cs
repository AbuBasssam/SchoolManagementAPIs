using ApplicationLayer.Features.Students.Helper;

namespace ApplicationLayer.Features.UserFeature.Commands.AddAdminCommand
{
    public class AddAdminDTO
    {
        public InfoDTO InfoDTO { get; set; }
        public UserInfoDTO UserInfoDTO { get; set; }
        public string Email { get; set; }

        public AddAdminDTO(InfoDTO infoDTO, UserInfoDTO userInfoDTO, string email)
        {
            InfoDTO = infoDTO;
            UserInfoDTO = userInfoDTO;
            Email = email;
        }
    }


}
