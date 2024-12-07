using ApplicationLayer.Enums;
using DomainLayer.Enums;

namespace ApplicationLayer.Features.Students.Helper
{
    public class InfoDTO : IPersonInfo
    {
        #region var/prop(s)

        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public enNatinoality Nationality { get; set; }
        public string? ImagePath { get; set; }

        #endregion

        #region Constructure(s)
        public InfoDTO(string nationalNO, string firstName, string secondName, string thirdName, string lastName,
            DateTime dateOfBirth, enGender gender, enNatinoality nationality, string? imagePath)
        {
            NationalNO = nationalNO;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationality = nationality;
            ImagePath = imagePath;
        }
        #endregion

    }


}
