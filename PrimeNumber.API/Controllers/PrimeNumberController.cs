using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Service;

namespace PrimeNumber.API.Controllers
{

    public class PrimeNumberController : CustomBaseController
    {

        private readonly IPrimeNumberService _service;

        public PrimeNumberController(IPrimeNumberService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            //var a = User.IsInRole("admin");
            var numberSets = await _service.GetAllAsync();
            return CreateActionResult(CustomResponseDto<IEnumerable<CalculatedSetDto>>.Success(200, numberSets));

        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]FindRequestDto findRequestDto)
        {
            var result = await _service.AddAsync(findRequestDto);
            return CreateActionResult(CustomResponseDto<CalculatedSetDto>.Success(200, result));
        }


        
    }
}
