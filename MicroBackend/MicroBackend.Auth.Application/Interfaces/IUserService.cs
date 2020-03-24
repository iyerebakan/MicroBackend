﻿using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Auth.Application.Interfaces
{
    public interface IUserService
    {
        Task<IList<string>> GetRolesAsync(ApplicationUsers applicationUser);
        Task<ApplicationUsers> UserExists(string email);
        Task<ApplicationUsers> GetUserByUserId(string userid);
        Task<bool> AddRoleToUser(RoletoUserDto roletoUserDto);
        Task<bool> CheckPasswordAsync(ApplicationUsers applicationUser, string password);
        Task<bool> CreateAsync(ApplicationUsers applicationUser, string password);
    }
}
