using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Data.Repository;
using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Models;
using MicroBackend.Domain.Core.Services.Constants;
using MicroBackend.Domain.Core.Services.Interfaces;
using MicroBackend.Domain.Core.Services.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Auth.Application.Services
{
    public class UserManager : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUsers> UserExists(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<ApplicationUsers> GetUserByUserId(string userid)
        {
            return await _userRepository.FindByIdAsync(userid);
        }

        public async Task<IServiceDataResult<bool>> AddRoleToUser(RoletoUserDto roletoUserDto)
        {
            var result = await _userRepository.AddToRoleAsync(await GetUserByUserId(roletoUserDto.Id), roletoUserDto.Rolename);
            if (result.Succeeded)
            {
                return new SuccessDataResult<bool>(true);
            }

            return new ErrorDataResult<bool>(false, GlobalErrors.NotCompleted, "Roles does not save to database..!");
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUsers applicationUser)
        {
            return await _userRepository.GetRolesAsync(applicationUser);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUsers applicationUser, string password)
        {
            return await _userRepository.CheckPasswordAsync(applicationUser, password);
        }

        public async Task<bool> CreateAsync(ApplicationUsers applicationUser, string password)
        {
            var result = await _userRepository.CreateAsync(applicationUser, password);
            return result.Succeeded;
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUsers applicationUser)
        {
            return await _userRepository.IsEmailConfirmedAsync(applicationUser);
        }
    }
}
