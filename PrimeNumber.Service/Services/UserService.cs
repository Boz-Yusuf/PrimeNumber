using Microsoft.AspNetCore.Identity;
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


        public async Task<bool> CreateUser(RegisterDto registerDto)
        {
            var identityUser = new IdentityUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
            };

            var result = await _userRepository.RegisterUserAsync(identityUser, registerDto.Password);


            return result;
        }
    }
}
