using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Core.Service
{
    public interface IPrimeNumberService
    {
        Task<IEnumerable<CalculatedSet>> GetAllAsync();
        Task<CalculatedSet> AddAsync(FindRequestDto set);

    }
}
