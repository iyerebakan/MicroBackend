using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Data.Repository;
using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Models;
using MicroBackend.Domain.Core.Services.Constants;
using MicroBackend.Domain.Core.Services.Interfaces;
using MicroBackend.Domain.Core.Services.Results;
using MicroBackend.Domain.Core.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroBackend.Domain.Core.Validation;
using MicroBackend.Auth.Application.ValidationRules;
using MicroBackend.Domain.Core.Services.Business;
using MicroBackend.Domain.Core.Log.Services;
using MicroBackend.Domain.Core.Log.Logger;
using Castle.Core.Logging;

namespace MicroBackend.Auth.Application.Services
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IServiceDataResult<AccessToken>> CreateToken(ApplicationUsers applicationUser)
        {
            var roles = await _userService.GetRolesAsync(applicationUser);

            var tokenInfo = new TokenInfo
            {
                Email = applicationUser.Email,
                Roles = roles.ToArray(),
                Id = applicationUser.Id,
                UserName = applicationUser.UserName
            };
            return new SuccessDataResult<AccessToken>(_tokenHelper.CreateToken(tokenInfo));
        }

        public async Task<IServiceDataResult<ApplicationUsers>> ExternalLogin(LoginEmailDto loginEmail)
        {
            var user = await _userService.UserExists(loginEmail.Email);
            if (user != null)
            {
                if (await _userService.IsEmailConfirmedAsync(user))
                {
                    return new SuccessDataResult<ApplicationUsers>(user);
                }
                else
                {
                    return new ErrorDataResult<ApplicationUsers>(user,GlobalErrors.EmailIsNotVerified, "User's email is not verified..!");
                }
            }

            return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotFound, "User does not exists..!");
        }

        public async Task<IServiceDataResult<ApplicationUsers>> LoginWithPassword(LoginEmailAndPasswordDto loginEmailAndPassword)
        {
            var user = await _userService.UserExists(loginEmailAndPassword.Email).ConfigureAwait(true);
            if (user != null)
            {
                if (await _userService.IsEmailConfirmedAsync(user))
                {
                    var userToCheck = await _userService.CheckPasswordAsync(user, loginEmailAndPassword.Password);
                    if (!userToCheck)
                    {
                        return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotFound, "User's password wrong..!");
                    }
                    LoggerService.InfoAsync(new DatabaseLogger(message: "testdeneme", data: loginEmailAndPassword));
                    return new SuccessDataResult<ApplicationUsers>(user);
                }
                else
                {
                    return new ErrorDataResult<ApplicationUsers>(user,GlobalErrors.EmailIsNotVerified, "User's email is not verified..!");
                }

            }

            return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotFound, "User does not exists..!");
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public async Task<IServiceDataResult<ApplicationUsers>> Register(RegisterDto register)
        {
            var user = await _userService.UserExists(register.Email);
            if (user != null)
            {
                return new ErrorDataResult<ApplicationUsers>(user, GlobalErrors.NotCompleted, "User is already registered..!");
            }

            user = new ApplicationUsers { UserName = register.UserName, Email = register.Email };
            var result = await _userService.CreateAsync(user, register.Password);
            if (result)
                return new SuccessDataResult<ApplicationUsers>(user);

            return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotCompleted, "User does not save to database..!");
        }

    }
}
