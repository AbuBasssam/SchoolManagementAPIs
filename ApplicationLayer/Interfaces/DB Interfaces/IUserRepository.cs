using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IUserRepository : IStaticGenericRepository<User>
    {
        //Task<bool> ChangePasswordAsync(string UserName, string newPassword);
        IQueryable<User> GetByUserName(string UserName);
        IQueryable<User> GetUserByEmail(string email);
        Task<bool> IsExistsByEmailAsync(string email);
        Task<bool> IsExistsByUserNameAsync(string userName);
        Task<bool> UpdateInfo(string userName, Person personInfo);
    }


}
