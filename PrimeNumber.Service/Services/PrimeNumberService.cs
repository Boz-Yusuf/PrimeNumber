using AutoMapper;
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
        private readonly IMapper _mapper;

        public PrimeNumberService(IPrimeNumberRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CalculatedSetDto> AddAsync(FindRequestDto set)
        {
            string numbers = "";
            foreach(int number in set.NumberSet)
            {
                numbers += number.ToString();
                numbers += ",";
            }
            numbers = numbers.Substring(0, numbers.Length - 1);

            int BiggestPrime = FindBiggestPrime(set.NumberSet);
            var calculatedSet = new CalculatedSet() { BiggestPrimeNumber= BiggestPrime , Numbers = numbers };

            await _repository.AddAsync(calculatedSet);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CalculatedSetDto>(calculatedSet);
        }

        public async Task<IEnumerable<CalculatedSetDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CalculatedSetDto>>(result);
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


            for(int i = 2; i <= (number / 2)  ; i++)
            {
                if(number % i == 0)
                    return false;
            }

            return true;
        }


    }
}
