using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Domain.Core.Security.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBackend.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("externallogin")]
        public async Task<IActionResult> ExternalLogin(LoginEmailDto loginEmailDto)
        {
            var userToLogin = await _authService.ExternalLogin(loginEmailDto);
            if (!userToLogin.Success)
                return Ok(userToLogin);

            var result = await _authService.CreateToken(userToLogin.Data).ConfigureAwait(true);
            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AccessToken), (int)HttpStatusCode.OK)] 
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login(LoginEmailAndPasswordDto loginEmailAndPasswordDto)
        {
            var userToLogin = await _authService.LoginWithPassword(loginEmailAndPasswordDto);
            if (!userToLogin.Success)
                return Ok(userToLogin);

            var result = await _authService.CreateToken(userToLogin.Data).ConfigureAwait(true);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var user = await _authService.Register(register);
            return Ok(user);
        }
    }
}