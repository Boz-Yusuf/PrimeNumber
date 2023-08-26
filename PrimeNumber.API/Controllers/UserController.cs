﻿using Microsoft.AspNetCore.Mvc;
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
            var result = await _userService.CreateUserAsync(registerDto);
      

            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
           
            if(ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(loginDto);


                if(result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);


            }

            return BadRequest("Some Properties are not valid");
        }










    }
}
