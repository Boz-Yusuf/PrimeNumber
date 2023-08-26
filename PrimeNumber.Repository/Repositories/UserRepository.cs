using Microsoft.AspNetCore.Identity;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {


        private readonly UserManager<IdentityUser> _userManager;


        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager; 
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
    }
}
