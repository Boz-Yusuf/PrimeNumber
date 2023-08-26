using Microsoft.AspNetCore.Identity;

namespace PrimeNumber.Core.Repositories
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(IdentityUser user, string password);
    }
}
