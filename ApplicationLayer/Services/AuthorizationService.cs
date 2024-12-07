using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;
using DomainLayer.Requests;
using DomainLayer.Responses;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace ApplicationLayer.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Field(s)
        private readonly RoleManager<Role> _role;
        private readonly UserManager<User> _user;
        private readonly IUserRepository _repo;

        #endregion

        #region Constructure(s)
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager, IUserRepository repo)
        {
            _role = roleManager;
            _user = userManager;
            _repo = repo;
        }

        #endregion

        #region Action Method(s)
        public IQueryable<Role> GetRoleById(int Id)
            => _role.Roles.Where(r => r.Id == Id);

        public IQueryable<Role> GetRoleByName(string RoleName)
            => _role.Roles.Where(r => r.Name == RoleName);

        public IQueryable<Role> GetRolesList()
            => _role.Roles;

        public async Task<IdentityResult> AddRoleAsync(Role NewRole)
            => await _role.CreateAsync(NewRole);

        public async Task<IdentityResult> UpdateRoleAsync(Role Role)
            => await _role.UpdateAsync(Role);

        public async Task<bool> IsRoleExistsAsync(string Name)
            => await _role.RoleExistsAsync(Name);

        public async Task<bool> IsRoleExistsAsyncExceptSelf(string Name)
            => await _role.RoleExistsAsync(Name);

        public async Task<bool> IsRoleExistsAsync(int Id)
            => await _role.FindByIdAsync(Id.ToString()) != null;

        public async Task<IdentityResult> DeleteRoleAsync(Role Role)
            => await _role.DeleteAsync(Role);

        public async Task<ManageUserClaimsResponse> ManageUserClaimData(User user)
        {
            var response = new ManageUserClaimsResponse();
            var usercliamsList = new List<UserClaims>();
            response.UserId = user.Id;
            //Get USer Claims
            var userClaims = await _user.GetClaimsAsync(user); //edit
                                                               //create edit get print
            foreach (var claim in DefalutAdminClaims.claims)
            {
                var userclaim = new UserClaims();
                userclaim.Type = claim.Type;
                if (userClaims.Any(x => x.Type == claim.Type))
                {
                    userclaim.Value = true;
                }
                else
                {
                    userclaim.Value = false;
                }
                usercliamsList.Add(userclaim);
            }
            response.userClaims = usercliamsList;
            //return Result
            return response;
        }



        public async Task<string> UpdateUserClaims(UpdateUserClaimsRequest request)
        {
            var transact = _repo.BeginTransaction();
            try
            {
                var user = await _user.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return "UserIsNull";
                }
                //remove old Claims
                var userClaims = await _user.GetClaimsAsync(user);
                var removeClaimsResult = await _user.RemoveClaimsAsync(user, userClaims);
                if (!removeClaimsResult.Succeeded)
                    return "FailedToRemoveOldClaims";
                var claims = request.userClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));

                var addUserClaimResult = await _user.AddClaimsAsync(user, claims);
                if (!addUserClaimResult.Succeeded)
                    return "FailedToAddNewClaims";

                await transact.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToUpdateClaims";
            }
        }

        #endregion
    }


}
