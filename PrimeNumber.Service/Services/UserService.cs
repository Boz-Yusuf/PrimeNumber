using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Repositories;
using PrimeNumber.Core.Service;
using System.Data;
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




        public async Task<UserRegisterResponseDto> LoginAsync(LoginDto loginDto)
        {
            List<string> errorList = new List<string>();
            var user = await _userRepository.GetUserByEmail(loginDto.Email);

            if (user == null)
            {
                errorList.Add("User not found");
                return new UserRegisterResponseDto
                {
                    Errors = errorList,
                    IsSuccess = false
                };
            }


            var result = await _userRepository.ValidatePassword(user, loginDto.Password);

            if (result == false)
            {
                errorList.Add("User Credentials incorrect");
                return new UserRegisterResponseDto
                {
                    Errors= errorList,
                    IsSuccess = false
                };
            }


            var userRoles = _userRepository.GetUserRoles(user.Id);

            var claims = new[]
            {
                new Claim("Email", loginDto.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role,  userRoles.Contains("admin") ? "admin" : "user")
             
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256));


            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserRegisterResponseDto
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
            };

        }




    }
}
