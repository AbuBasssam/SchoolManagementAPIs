using DomainLayer.Contracts;
using DomainLayer.Enums;

namespace DomainLayer.Entities
{

    public class Person : IEntity
    {
        #region var/prop
        public int Id { get; set; }
        public string NationalNO { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string ThirdName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string FullName
            => FirstName + " " + SecondName + " " + ThirdName + " " + LastName;

        public enGender Gender { get; set; }
        public int NationalityID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImagePath { get; set; }
        public Nationality Nationality { get; set; } = null!;

        #endregion

    }
}
