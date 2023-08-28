using Microsoft.AspNetCore.Identity;
using PrimeNumber.Core.DTOs;

namespace PrimeNumber.Core.Repositories
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(IdentityUser user, string password);
        Task<IdentityUser> GetUserByEmail(string email);
        Task<bool> ValidatePassword(IdentityUser user, string password);
        List<string> GetUserRoles(string Id);
    }
}
