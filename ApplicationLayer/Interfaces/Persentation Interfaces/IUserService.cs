using ApplicationLayer.Models;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApplicationLayer.Interfaces
{
    public interface IUserService : IGeneralUserService, IAddUserService
    {
        #region Action Method(s)
        IQueryable<User> GetById(int id);

        IQueryable<User> GetByUserName(string UserName);
        IQueryable<User> GetByNationalNO(string NationalNo);


        IQueryable<User> GetUsersPage(int pageNumber);

        Task<bool> IsUserExistsByIdAsync(int Id);

        Task<bool> IsExistsByEmailAsync(string Email);

        Task<bool> IsExistsByUserNameAsync(string UserName);

        Task<PaginatingResult> GetPaginateInfo();

        Task<Role> GetUserRoleAsync(string UserName);

        Task<bool> CheckPasswordAsync(User User, string Password);

        // Task<IdentityResult> UpdateUserRolesAsync(string UserName, Role NewRole);

        //Task<IdentityResult> RemoveFromRolesAsync(User User, IEnumerable<string> Roles);

        //Task<IdentityResult> AddToRoleAsync(User User, Role Role);

        Task<IdentityResult> UpdateUserAsync(User UpdatedUser);

        Task<bool> UpdateUserRoleAsync(string UserName, int RoleID);

        #endregion

    }
}
