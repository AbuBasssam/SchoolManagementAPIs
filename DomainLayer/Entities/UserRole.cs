using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class UserRole : IdentityUserRole<int>
    {

        #region var/prop
        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
        #endregion

    }
}
