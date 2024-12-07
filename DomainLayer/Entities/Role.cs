using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class Role : IdentityRole<int>
    {

        #region Vars / Props

        public ICollection<User>? Users { get; private set; }
        #endregion

        #region Constructor(s)

        #endregion

    }
}
