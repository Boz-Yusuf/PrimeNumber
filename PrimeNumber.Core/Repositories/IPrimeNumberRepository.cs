using PrimeNumber.Core.Entities;

namespace PrimeNumber.Core.Repositories
{
    public interface IPrimeNumberRepository
    {
        Task<CalculatedSet> GetByIdAsync(int id);
        IEnumerable<Task<CalculatedSet>> GetAllAsync();
        Task AddAsync(CalculatedSet set);
        void Update(CalculatedSet set);
        void Remove(CalculatedSet set);
    }
}
