using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Domain.Dtos;
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
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginEmailDto loginEmailDto)
        {
            var userToLogin = await _authService.Login(loginEmailDto);
            if (userToLogin == null)
            {
                return BadRequest("User does not exists");
            }

            var result = await _authService.CreateToken(userToLogin).ConfigureAwait(true);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Sorun var.");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var user = await _authService.Register(register);
            if (user == null)
            {
                return BadRequest("User does not saved.");
            }

            var result = await _authService.CreateToken(user).ConfigureAwait(true);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Sorun var.");
        }
    }
}