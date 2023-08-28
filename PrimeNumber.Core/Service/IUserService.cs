using PrimeNumber.Core.DTOs;

namespace PrimeNumber.Core.Service
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(RegisterDto registerDto);

        Task<UserRegisterResponseDto> LoginAsync(LoginDto loginDto);

    }
}
