using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Data.Repository;
using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Dtos.UserDtos;
using MicroBackend.Auth.Domain.Models;
using MicroBackend.Domain.Core.Services.Constants;
using MicroBackend.Domain.Core.Services.Interfaces;
using MicroBackend.Domain.Core.Services.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public async Task<IServiceDataResult<ApplicationUsers>> EmailVerifiedAsync(ApplicationUsers applicationUser,string code)
        {
            try
            {
                var result = await _userRepository.ConfirmEmailAsync(applicationUser, Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code)));
                if (result.Succeeded)
                {
                    applicationUser.EmailConfirmed = true;
                    await _userRepository.UpdateAsync(applicationUser);
                    return new SuccessDataResult<ApplicationUsers>(applicationUser);
                }
                return new ErrorDataResult<ApplicationUsers>(applicationUser, GlobalErrors.NotCompleted, message: result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ApplicationUsers>(applicationUser,GlobalErrors.NotCompleted,message: ex.Message);
            }
            
        }

        public async Task<ApplicationUsers> FindUserByEmail(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<IServiceDataResult<GenerateEmailDto>> GenerateEmailVerificationCode(ApplicationUsers applicationUser)
        {
            try
            {
                string code = await _userRepository.GenerateEmailConfirmationTokenAsync(applicationUser);
                return new SuccessDataResult<GenerateEmailDto>(new GenerateEmailDto
                {
                    VerificationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code)),
                    Id = applicationUser.Id,
                    Email = applicationUser.Email
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GenerateEmailDto>(new GenerateEmailDto
                {
                    Email = applicationUser.Email,
                    Id = applicationUser.Id
                }, GlobalErrors.NotCompleted, message: ex.Message);
            }
        }

        public async Task<IServiceDataResult<GeneratePasswordDto>> GeneratePasswordVerificationCode(ApplicationUsers applicationUser)
        {
            try
            {
                string code = await _userRepository.GeneratePasswordResetTokenAsync(applicationUser);
                return new SuccessDataResult<GeneratePasswordDto>(new GeneratePasswordDto
                {
                    VerificationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code)),
                    Id = applicationUser.Id,
                    Email = applicationUser.Email
                }, message: "Password verification code has created..!");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GeneratePasswordDto>(new GeneratePasswordDto
                {
                    Email = applicationUser.Email,
                    Id = applicationUser.Id
                }, GlobalErrors.NotCompleted, message: ex.Message);
            }
        }

        public async Task<IServiceDataResult<ApplicationUsers>> ResetPasswordAsync(ApplicationUsers applicationUser, string token, string newPassword)
        {
            try
            {
                var result = await _userRepository.ResetPasswordAsync(applicationUser,
                    Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token)),
                    newPassword);
                if (result.Succeeded)
                {
                    return new SuccessDataResult<ApplicationUsers>(applicationUser);
                }
                return new ErrorDataResult<ApplicationUsers>(applicationUser, GlobalErrors.NotCompleted, 
                            message: result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ApplicationUsers>(applicationUser, GlobalErrors.NotCompleted, message: ex.Message);
            }
        }
    }
}
