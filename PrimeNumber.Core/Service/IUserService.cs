using PrimeNumber.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Core.Service
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(RegisterDto registerDto);

        Task<bool> LoginAsync(LoginDto loginDto);
    }
}
