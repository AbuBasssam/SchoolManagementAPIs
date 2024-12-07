using ApplicationLayer.Features.Students.Helper;

namespace ApplicationLayer.Features.Students.Commands.AddNewStudent
{
    public class AddStudentDTO
    {
        #region Field(s)
        public InfoDTO InfoDTO { get; set; }
        public UserInfoDTO UserInfoDTO { get; set; }

        #endregion

        #region Constructure(s)

        public AddStudentDTO(InfoDTO infoDTO, UserInfoDTO userInfoDTO)
        {
            InfoDTO = infoDTO;
            UserInfoDTO = userInfoDTO;
        }

        #endregion

    }


}
