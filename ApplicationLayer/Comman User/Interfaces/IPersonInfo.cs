using ApplicationLayer.Enums;
using DomainLayer.Enums;

namespace ApplicationLayer.Features.Students.Helper
{
    public interface IPersonInfo
    {

        #region var/prop(s)

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public enNatinoality Nationality { get; set; }

        #endregion

    }



}
