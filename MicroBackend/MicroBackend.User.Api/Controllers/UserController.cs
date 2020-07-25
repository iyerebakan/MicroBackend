using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;
using MicroBackend.User.Application.Interfaces;
using MicroBackend.User.Domain.Dtos;
using MicroBackend.User.Domain.Dtos.AuthDtos;
using MicroBackend.User.Domain.Dtos.UserDtos;
using MicroBackend.User.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroBackend.User.Api.Controllers
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

        [HttpGet("getUserRoles")]
        public async Task<IActionResult> GetRolesAsync(ApplicationUsers applicationUsers)
        {
            return Ok(await _userService.GetRolesAsync(applicationUsers));
        }

        [HttpGet("userExists")]
        public async Task<IActionResult> UserExists(string email)
        {
            return Ok(await _userService.UserExists(email));
        }

        [HttpPost("isEmailConfirmed")]
        public async Task<IActionResult> IsEmailConfirmedAsync(ApplicationUsers applicationUsers)
        {
            return Ok(await _userService.IsEmailConfirmedAsync(applicationUsers));
        }

        [HttpPost("checkPassword")]
        public async Task<IActionResult> CheckPasswordAsync(CheckPasswordDto checkPasswordDto)
        {
            return Ok(await _userService.CheckPasswordAsync(checkPasswordDto.ApplicationUsers, checkPasswordDto.Password));
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateAsync(RegisterDto register)
        {
            var user = new ApplicationUsers { UserName = register.UserName, Email = register.Email };
            return Ok(await _userService.CreateAsync(user, register.Password));
        }

        [HttpGet("loginProvider")]
        public async Task<IActionResult> LoginProviderAsync(string loginProvider,string providerKey)
        {
            var user = await _userService.FindByLoginAsync(loginProvider, providerKey);
            return Ok(user);
        }

    }
}