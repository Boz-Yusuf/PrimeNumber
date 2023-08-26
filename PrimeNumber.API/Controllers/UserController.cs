using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Service;

namespace PrimeNumber.API.Controllers
{

    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var result = await _userService.CreateUserAsync(registerDto);
      

            return Ok(result);
        }








    }
}
