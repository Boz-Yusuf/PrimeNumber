using Microsoft.AspNetCore.Mvc;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Service;

namespace PrimeNumber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeNumberController : ControllerBase
    {

        private readonly IPrimeNumberService _service;

        public PrimeNumberController(IPrimeNumberService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var numberSets = await _service.GetAllAsync();
            return Ok(numberSets);
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]FindRequestDto findRequestDto)
        {
            var result = await _service.AddAsync(findRequestDto);
            return Ok(result);
        }



    }
}
