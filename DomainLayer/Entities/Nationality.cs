using DomainLayer.Contracts;

namespace DomainLayer.Entities
{
    public class Nationality : IEntity
    {
        #region var/prop
        public int Id { get; set; }
        public string NationalityName { get; set; } = null!;

        #endregion


    }
}
