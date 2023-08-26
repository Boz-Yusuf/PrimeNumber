using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Repositories;
using PrimeNumber.Core.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimeNumber.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
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

        public async Task<UserRegisterResponse> LoginAsync(LoginDto loginDto)
        {

            var user = await _userRepository.GetUserByEmail(loginDto.Email);

            if (user == null)
                return new UserRegisterResponse
                {
                    Message = "User not found",
                    IsSuccess = false,
                };

            var result = await _userRepository.ValidatePassword(user, loginDto.Password);

            if(result == false)
                return new UserRegisterResponse
                {
                    Message = "User Credentials wrong",
                    IsSuccess = false,
                };

            var claims = new[]
            {
                new Claim("Email", loginDto.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256));


            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserRegisterResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
            };

        }
    }
}
