using ApplicationLayer.Features.Students.Helper;

namespace ApplicationLayer.Interfaces
{

    public interface IGeneralUserService
    {
        Task<bool> ChangePasswordAsync(string UserName, string CrurentPassword, string NewPassword);
        Task<bool> UpdateUserInfoAsync(string UserName, UpdateInfoDTO entity);
    }
}
