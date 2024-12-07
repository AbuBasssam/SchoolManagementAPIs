using DomainLayer.Enums;

namespace ApplicationLayer.Models
{
    public record AddUserInfoDTO(string NationalNO, string UserName, string FullName, DateTime DateOfBirth, string NationalityName, string? ImagePath)
    {
        private enGender _Gender { get; set; }

        public string Gender => _Gender.ToString();

        public AddUserInfoDTO(string nationalNO, string userName, string fullName,
            DateTime dateOfBirth, string nationalityName,
            enGender gender, string? imagePath) : this(nationalNO, userName, fullName, dateOfBirth, nationalityName, imagePath)
        {
            _Gender = gender;
        }
    }
}