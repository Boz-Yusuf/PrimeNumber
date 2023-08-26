using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Entities;
using PrimeNumber.Core.Repositories;
using PrimeNumber.Core.Service;
using PrimeNumber.Core.UnitOfWork;

namespace PrimeNumber.Service.Services
{
    public class PrimeNumberService : IPrimeNumberService
    {
        private readonly IPrimeNumberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PrimeNumberService(IPrimeNumberRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CalculatedSet> AddAsync(FindRequestDto set)
        {
            string numbers = "";
            foreach(int number in set.NumberSet)
            {
                numbers += number.ToString();
                numbers += ",";
            }

            int BiggestPrime = FindBiggestPrime(set.NumberSet);
            var calculatedSet = new CalculatedSet() { BiggestPrimeNumber= BiggestPrime , Numbers = numbers };

            await _repository.AddAsync(calculatedSet);
            await _unitOfWork.CommitAsync();

            return calculatedSet;
        }

        public async Task<IEnumerable<CalculatedSet>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public int FindBiggestPrime(List<int> numberList)
        {
            int biggestPrime = -1;


            foreach(int number in numberList)
            {
                if (isPrime(number) && (number > biggestPrime))
                {
                    biggestPrime = number;
                }
            }


            return biggestPrime;
        }


        public bool isPrime(int number)
        {

            if(number == 2)
                return true;


            for(int i = 2; i < (number / 2); i++)
            {
                if(number % i == 0)
                    return false;
            }

            return true;
        }


    }
}
