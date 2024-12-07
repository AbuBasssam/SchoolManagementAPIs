using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApplicationLayer.Interfaces
{
    public interface IAddUserService
    {
        Task<IdentityResult> AddNewUserAsync(User NewUser, string password);

    }
}
