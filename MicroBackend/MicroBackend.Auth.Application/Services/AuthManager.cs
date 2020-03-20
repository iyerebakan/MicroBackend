using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Data.Repository;
using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Models;
using MicroBackend.Domain.Core.Utilities.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBackend.Auth.Application.Services
{
    public class AuthManager : IAuthService
    {
        private readonly AuthRepository _authRepository;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(AuthRepository authRepository, ITokenHelper tokenHelper)
        {
            _authRepository = authRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateToken(ApplicationUsers applicationUser)
        {
            var roles = await _authRepository.GetRolesAsync(applicationUser);

            var tokenInfo = new TokenInfo
            {
                Email = applicationUser.Email,
                Roles = roles.ToArray(),
                Id = applicationUser.Id,
                UserName = applicationUser.UserName
            };
            return _tokenHelper.CreateToken(tokenInfo);
        }

        public async Task<ApplicationUsers> Login(LoginEmailDto loginEmail)
        {
            var user = await UserExists(loginEmail.Email);
            if(user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<ApplicationUsers> LoginWithPassword(LoginEmailAndPasswordDto loginEmailAndPassword)
        {
            var user = await UserExists(loginEmailAndPassword.Email).ConfigureAwait(true);
            if (user != null)
            {
                var userToCheck = await _authRepository.CheckPasswordAsync(user, loginEmailAndPassword.Password);
                if (!userToCheck)
                {
                    return null;
                }

                return user;
            }

            return null;
        }

        public async Task<ApplicationUsers> Register(RegisterDto register)
        {
            var user = new ApplicationUsers { UserName = register.UserName, Email = register.Email };
            var result = await _authRepository.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }

        public async Task<ApplicationUsers> UserExists(string email)
        {
            return await _authRepository.FindByEmailAsync(email);
        }
    }
}
