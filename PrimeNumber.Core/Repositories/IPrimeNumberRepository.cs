using PrimeNumber.Core.Entities;

namespace PrimeNumber.Core.Repositories
{
    public interface IPrimeNumberRepository
    {
        Task<IEnumerable<CalculatedSet>> GetAllAsync();
        Task AddAsync(CalculatedSet set);

    }
}
