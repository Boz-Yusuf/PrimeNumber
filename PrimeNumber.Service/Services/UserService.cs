using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Repositories;
using PrimeNumber.Core.Service;

namespace PrimeNumber.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> CreateUserAsync(RegisterDto registerDto)
        {
            var identityUser = new IdentityUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
            };

            var result = await _userRepository.RegisterUserAsync(identityUser, registerDto.Password);


            return result;
        }

        public async Task<bool> LoginAsync(LoginDto loginDto)
        {

            var user = await _userRepository.GetUserByEmail(loginDto.Email);

            if (user == null)
                return false;

            var result = await _userRepository.ValidatePassword(user, loginDto.Password);

            if(result == false)
                return false;





            return true;


        }
    }
}
