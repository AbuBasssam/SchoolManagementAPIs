using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Exceptoins.Student;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        #region Field(s)

        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _repo;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructure(s)
        public UserService(IUserRepository repo, UserManager<User> userManager, IAuthorizationService authService, IMapper mapper)
        {
            _userManager = userManager;
            _authorizationService = authService;
            _repo = repo;
            _mapper = mapper;

        }
        #endregion

        #region Action Method(s)

        public IQueryable<User> GetById(int id)
            => _repo.GetById(id);

        public IQueryable<User> GetUserByEmail(string Email) => _repo.GetUserByEmail(Email);

        public IQueryable<User> GetByUserName(string UserName)
           => _userManager.Users.Where(x => x.UserName!.Equals(UserName));

        public IQueryable<User> GetUser(int Id, string UserName, string Email)
         => _userManager.Users.Where(x => x.Id == Id || x.Email!.ToLower().Equals(Email.ToLower()) || x.UserName!.ToLower().Equals(UserName.ToLower()));

        public IQueryable<User> GetUsersPage(int pageNumber)
            => _repo.GetPage(pageNumber);


        public async Task<bool> IsUserExistsByIdAsync(int Id)
            => await _repo.IsExistsByIdAsync(Id);

        public async Task<bool> IsExistsByEmailAsync(string Email)
            => await _repo.IsExistsByEmailAsync(Email);

        public async Task<bool> IsExistsByUserNameAsync(string UserName)
            => await _repo.IsExistsByUserNameAsync(UserName);

        public async Task<bool> ChangePasswordAsync(string UserName, string CrurentPassword, string NewPassword)
        {
            var User = await GetByUserName(UserName).Include(u => u.PersonInfo).FirstOrDefaultAsync();
            if (User is not null)
            {
                IdentityResult result = await _userManager.ChangePasswordAsync(User!, CrurentPassword, NewPassword);

                return result.Succeeded ? true : throw new Exception($"{string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            return false;
        }

        public async Task<bool> UpdateUserInfoAsync(string UserName, UpdateInfoDTO entity)
        {
            var User = await _CheckUserExists(UserName);

            _mapper.Map(entity, User.PersonInfo);

            return await _repo.UpdateInfo(UserName, User.PersonInfo);

        }

        private async Task<User> _CheckUserExists(string UserName)
        {
            var User = await GetByUserName(UserName).Include(u => u.PersonInfo).AsNoTracking().FirstOrDefaultAsync();

            return (User is not null) ? User : throw new UserExistsException(UserName);



        }

        public async Task<IdentityResult> AddNewUserAsync(User NewUser, string password)
            => await _userManager.CreateAsync(NewUser, password);

        public async Task<bool> CheckPasswordAsync(User User, string Password)
           => await _userManager.CheckPasswordAsync(User, Password);

        public async Task<PaginatingResult> GetPaginateInfo() => await _repo.GetPaginateInfo();

        public async Task<IdentityResult> UpdateUserAsync(User UpdatedUser)
           => await _userManager.UpdateAsync(UpdatedUser);
        public async Task<bool> UpdateUserRoleAsync(string UserName, int RoleID)
          => await _userManager.Users.Where(u => u.UserName!.Equals(UserName)).ExecuteUpdateAsync(x => x.SetProperty(u => u.RoleID, RoleID)) > 0;

        public Task<Role> GetUserRoleAsync(string UserName)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetByNationalNO(string NationalNo)
            => _userManager.Users.Where(x => x.PersonInfo.NationalNO.Equals(NationalNo));


        //public async Task<List<string>> GetUserRolesAsync(User User)
        //{
        //    return (await _userManager.GetRolesAsync(User)).ToList();

        //    /* var roles = await _userManager.GetRolesAsync(User);

        //     // Convert the string roles to enRole enum
        //     var enumRoles = roles
        //         .Select(role => Enum.TryParse(typeof(enRole), role, true, out var parsedRole) ? (enRole?)parsedRole : null)
        //         .Where(r => r.HasValue) // Filter valid roles
        //         .Select(r => r.Value)  // Extract the value
        //         .ToList();

        //     return enumRoles;*/


        //}


        //public async Task<IdentityResult> RemoveFromRolesAsync(User User, IEnumerable<string> Roles)
        //    => await _userManager.RemoveFromRolesAsync(User, Roles);

        //public async Task<IdentityResult> AddToRoleAsync(User User, Role Role)
        //{
        //    User.Role = Role;
        //    return await _userManager.UpdateAsync(User);
        //    //User.UserRoles!.Add(new UserRole { Role = Role });
        //    //return await _userManager.UpdateAsync(User);
        //}

        //public async Task<IdentityResult> UpdateUserRolesAsync(User User, List<string> Roles)
        //    => await _userManager.UpdateAsync(User);

        //public async Task<IdentityResult> UpdateUserRolesAsync(string UserName, string NewRole)
        //{
        //    var User = await _userManager.Users.Where(x => x.UserName!.Equals(UserName)).Include(u => u.Role).FirstOrDefaultAsync();
        //    if (User is null)
        //        throw new UserNotExistsException(UserName);

        //    if (User.Role.Name!.Equals(NewRole))
        //        throw new Exception($"User : {UserName} already have this role");


        //    return await _userManager.UpdateAsync(User);


        //}

        #endregion

    }
}