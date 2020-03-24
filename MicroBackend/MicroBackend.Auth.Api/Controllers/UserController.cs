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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("addroletouser")]
        public async Task<IActionResult> AddRoleToUser(RoletoUserDto roletoUserDto)
        {
            return Ok(await _userService.AddRoleToUser(roletoUserDto));
        }

    }
}