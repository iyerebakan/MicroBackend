using MicroBackend.Auth.Application.Interfaces;
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
using MicroBackend.Domain.Core.RestClient;
using MicroBackend.Auth.Application.Constants;
using System.Runtime.InteropServices;
using MicroBackend.Auth.Domain.Dtos.AuthDtos;

namespace MicroBackend.Auth.Application.Services
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        public async Task<IServiceDataResult<AccessToken>> CreateToken(ApplicationUsers applicationUser)
        {
            var roles = await new RestClient<ApplicationUsers, List<string>>(UserAPI.GETUSERROLES).PostAsync(applicationUser);

            var tokenInfo = new TokenInfo
            {
                Email = applicationUser.Email,
                Roles =  roles != null ?  roles.ToArray() : new string[] { },
                Id = applicationUser.Id,
                UserName = applicationUser.UserName
            };
            return new SuccessDataResult<AccessToken>(_tokenHelper.CreateToken(tokenInfo));
        }

        public async Task<IServiceDataResult<ApplicationUsers>> ExternalLogin(LoginEmailDto loginEmail)
        {
            var user = await new RestClient<ApplicationUsers, ApplicationUsers>($"{ UserAPI.USEREXISTS}?email={loginEmail.Email}").GetAsync();
            if (user != null)
            {
                if (await new RestClient<ApplicationUsers, bool>(UserAPI.EMAILCONFIRMED).PostAsync(user))
                {
                    user = await new RestClient<ApplicationUsers, ApplicationUsers>($"{ UserAPI.LOGINPROVIDER}" +
                        $"?loginProvider={loginEmail.LoginProvider}&providerKey={loginEmail.ProviderKey}").GetAsync();
                    if (user != null)
                    {
                        return new SuccessDataResult<ApplicationUsers>(user);
                    }
                    return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotFound, "User does not exists..!");
                }
                else
                {
                    return new ErrorDataResult<ApplicationUsers>(user, GlobalErrors.EmailIsNotVerified, "User's email is not verified..!");
                }
            }

            return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotFound, "User does not exists..!");
        }

        public async Task<IServiceDataResult<ApplicationUsers>> LoginWithPassword(LoginEmailAndPasswordDto loginEmailAndPassword)
        {
            var user = await new RestClient<ApplicationUsers, ApplicationUsers>($"{ UserAPI.USEREXISTS}?email={loginEmailAndPassword.Email}").GetAsync();
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    var userToCheck = await new RestClient<CheckPasswordDto, bool>($"{UserAPI.CHECKPASSWORD}")
                        .PostAsync(new CheckPasswordDto { ApplicationUsers = user, Password = loginEmailAndPassword.Password });

                    if (!userToCheck)
                    {
                        return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotFound, "User's password wrong..!");
                    }
                    LoggerService.InfoAsync(new FileLogger(message: "User is logged in.", data: loginEmailAndPassword));
                    return new SuccessDataResult<ApplicationUsers>(user);
                }
                else
                {
                    LoggerService.WarnAsync(new DatabaseLogger(message: "User's email is not verified..!", data: user));
                    return new ErrorDataResult<ApplicationUsers>(user, GlobalErrors.EmailIsNotVerified, "User's email is not verified..!");
                }

            }

            return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotFound, "User does not exists..!");
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public async Task<IServiceDataResult<ApplicationUsers>> Register(RegisterDto register)
        {
            var user = await new RestClient<ApplicationUsers, ApplicationUsers>($"{ UserAPI.USEREXISTS}?email={register.Email}").GetAsync();
            if (user != null)
            {
                return new ErrorDataResult<ApplicationUsers>(user, GlobalErrors.NotCompleted, "User is already registered..!");
            }

            //user = new ApplicationUsers { UserName = register.UserName, Email = register.Email };
            var result = await new RestClient<RegisterDto, bool>($"{ UserAPI.CREATEUSER}").PostAsync(register);
            if (result)
                return new SuccessDataResult<ApplicationUsers>(user);

            return new ErrorDataResult<ApplicationUsers>(GlobalErrors.NotCompleted, "User does not save to database..!");
        }

    }
}
