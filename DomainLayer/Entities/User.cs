using DomainLayer.Contracts;
using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        #region var/prop
        public int RoleID { get; set; }
        public int PersonID { get; set; }
        public bool IsActive { get; set; }
        public Person PersonInfo { get; set; }

        public Role Role { get; set; }

        public ICollection<UserRefreshToken>? RefreshTokens { get; }

        #endregion



    }
}
