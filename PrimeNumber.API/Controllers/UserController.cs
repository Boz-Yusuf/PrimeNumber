using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(registerDto);
                return CreateActionResult(CustomResponseDto<bool>.Success(200, result));
            }

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            List<string> errorMessages = allErrors.Select(e => e.ErrorMessage).ToList();
            return CreateActionResult(CustomResponseDto<string>.Fail(400, "deneme"));

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
           
            if(ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(loginDto);


                if (result.IsSuccess)
                    return CreateActionResult(CustomResponseDto<string>.Success(200, result.Message));

                return CreateActionResult(CustomResponseDto<string>.Fail(400, result.Errors));


            }


            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            List<string> errorMessages = allErrors.Select(e => e.ErrorMessage).ToList();
            return CreateActionResult(CustomResponseDto<string>.Fail(400, errorMessages));
        }










    }
}
