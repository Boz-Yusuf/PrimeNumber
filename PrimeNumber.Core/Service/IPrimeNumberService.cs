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
        Task<CalculatedSet> GetByIdAsync(int id);
        Task<IEnumerable<CalculatedSet>> GetAllAsync();
        Task<CalculatedSet> AddAsync(CalculatedSet set);
        Task UpdateAsync(CalculatedSet set);
        Task RemoveAsync(CalculatedSet set);
    }
}
