using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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
        public async Task<IActionResult> VerifiedUserEmail([FromUri] string email,string code)
        {
            var user = _userService.FindUserByEmail(email);
            if (user == null)
                return BadRequest();

            return Ok(await _userService.EmailVerifiedAsync(user.Result,code));
        }

        [HttpPost("generateVerificationCode")]
        public async Task<IActionResult> GenerateVerificationCode([FromUri] string email)
        {
            var user = _userService.FindUserByEmail(email);
            if (user == null)
                return BadRequest();

            return Ok(await _userService.GenerateVerificationCode(user.Result));
        }

        [HttpPost("addroletouser")]
        public async Task<IActionResult> AddRoleToUser(RoletoUserDto roletoUserDto)
        {
            return Ok(await _userService.AddRoleToUser(roletoUserDto));
        }

    }
}