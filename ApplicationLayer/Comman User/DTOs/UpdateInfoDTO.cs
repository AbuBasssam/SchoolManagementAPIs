using ApplicationLayer.Enums;
using DomainLayer.Enums;

namespace ApplicationLayer.Features.Students.Helper
{
    public class UpdateInfoDTO : IPersonInfo
    {
        #region Field(s)

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public enNatinoality Nationality { get; set; }

        #endregion

        #region Constructure(s)
        public UpdateInfoDTO(string firstName, string secondName, string thirdName, string lastName,
            DateTime dateOfBirth, enGender gender, enNatinoality nationality)
        {

            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationality = nationality;
        }
        #endregion

    }

}
