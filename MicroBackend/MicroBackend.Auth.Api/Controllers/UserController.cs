using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace MicroBackend.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("verifiedEmail")]
        public async Task<IActionResult> VerifiedUserEmail(string email,string code)
        {
            var user = _userService.FindUserByEmail(email);
            if (user == null)  
                return BadRequest();

            return Ok(await _userService.EmailVerifiedAsync(user.Result,code));
        }
        
        [HttpPost("generateVerificationCode")]
        public async Task<IActionResult> GenerateVerificationCode(string email)
        {
            var user = _userService.FindUserByEmail(email);
            if (user == null)
                return BadRequest();

            return Ok(await _userService.GenerateEmailVerificationCode(user.Result));
        }

        [HttpPost("addroletouser")]
        public async Task<IActionResult> AddRoleToUser(RoletoUserDto roletoUserDto)
        {
            return Ok(await _userService.AddRoleToUser(roletoUserDto));
        }

        [HttpPost("generatePasswordVerificationCode")]
        public async Task<IActionResult> GeneratePasswordVerificationCode(string email)
        {
            var user = _userService.FindUserByEmail(email);
            if (user == null)
                return BadRequest();

            return Ok(await _userService.GeneratePasswordVerificationCode(user.Result));
        }

        [HttpGet("resetpassword")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePasswordDto changePassword)
        {
            var user = _userService.FindUserByEmail(changePassword.Email);
            if (user == null)
                return BadRequest();

            return Ok(await _userService.ResetPasswordAsync(user.Result, changePassword.VerificationToken,changePassword.NewPassword));
        }

    }
}