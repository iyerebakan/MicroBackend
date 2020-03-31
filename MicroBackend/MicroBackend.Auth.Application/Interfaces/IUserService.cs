using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Dtos.UserDtos;
using MicroBackend.Auth.Domain.Models;
using MicroBackend.Domain.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        Task<ApplicationUsers> FindUserByEmail(string email);
        Task<ApplicationUsers> GetUserByUserId(string userid);
        Task<IServiceDataResult<bool>> AddRoleToUser(RoletoUserDto roletoUserDto);
        Task<bool> CheckPasswordAsync(ApplicationUsers applicationUser, string password);
        Task<bool> CreateAsync(ApplicationUsers applicationUser, string password);
        Task<bool> IsEmailConfirmedAsync(ApplicationUsers applicationUser);
        Task<IServiceDataResult<GenerateEmailDto>> GenerateEmailVerificationCode(ApplicationUsers applicationUser);
        Task<IServiceDataResult<ApplicationUsers>> EmailVerifiedAsync(ApplicationUsers applicationUser,string code);
        Task<IServiceDataResult<GeneratePasswordDto>> GeneratePasswordVerificationCode(ApplicationUsers applicationUser);
        Task<IServiceDataResult<ApplicationUsers>> ResetPasswordAsync(ApplicationUsers applicationUser, string token, string newPassword);
    }
}
