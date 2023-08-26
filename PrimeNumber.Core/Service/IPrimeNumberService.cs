using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Entities;

namespace PrimeNumber.Core.Service
{
    public interface IPrimeNumberService
    {
        Task<IEnumerable<CalculatedSetDto>> GetAllAsync();
        Task<CalculatedSetDto> AddAsync(FindRequestDto set);
    }
}
