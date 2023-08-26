using Microsoft.EntityFrameworkCore;
using PrimeNumber.Core.Entities;
using PrimeNumber.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Repository.Repositories
{
    public class PrimeNumberRepository : IPrimeNumberRepository
    {

        protected readonly AppDbContext _context;
        private readonly DbSet<CalculatedSet> _dbSet;


        public PrimeNumberRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<CalculatedSet>();
        }


        public async Task AddAsync(CalculatedSet set)
        {
            await _dbSet.AddAsync(set);
         
        }

        public async Task<IEnumerable<CalculatedSet>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


    }
}
