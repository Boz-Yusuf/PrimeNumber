using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimeNumber.Core.Entities;
using PrimeNumber.Core.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PrimeNumber.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {


        private readonly UserManager<IdentityUser> _userManager;

        protected readonly AppDbContext _context;
        private readonly DbSet<CalculatedSet> _dbSet;


        public UserRepository(UserManager<IdentityUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _dbSet = _context.Set<CalculatedSet>();
        }


        //Register

        public async Task<bool> RegisterUserAsync(IdentityUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }


        //Login

        public async Task<IdentityUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> ValidatePassword(IdentityUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }


        public List<string> GetUserRoles(string userId)
        {
            var userRoles = _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(_context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                .ToList();

            return userRoles;
        }

    }
}
