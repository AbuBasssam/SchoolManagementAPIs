using ApplicationLayer.Features.Students.Helper;

namespace ApplicationLayer.Features.Teachers.Commands.AddNewTeacher
{
    public class AddTeacherDTO
    {

        public InfoDTO InfoDTO { get; set; }
        public UserInfoDTO UserInfoDTO { get; set; }
        public EDetailsDTO DetailsDTO { get; set; }
        public AddTeacherInfoDTO AddTeacherInfoDTO { get; set; }

        public AddTeacherDTO(InfoDTO infoDTO, UserInfoDTO userInfoDTO,
            EDetailsDTO detailsDTO, AddTeacherInfoDTO addTeacherInfoDTO)
        {
            InfoDTO = infoDTO;
            UserInfoDTO = userInfoDTO;
            DetailsDTO = detailsDTO;
            AddTeacherInfoDTO = addTeacherInfoDTO;
        }


    }
}