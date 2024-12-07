
using ApplicationLayer.Models;

namespace ApplicationLayer.Features.User.Queries
{
    public class UserQueryDTO
    {
        #region Field(s)
        public AddUserInfoDTO Info { get; set; }

        #endregion

        #region Constructure(s)
        public UserQueryDTO(AddUserInfoDTO info) => Info = info;

        #endregion

    }
}