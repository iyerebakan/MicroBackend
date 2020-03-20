using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Models;
using MicroBackend.Domain.Core.Utilities.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Auth.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUsers> Login(LoginEmailDto loginEmail);
        Task<ApplicationUsers> LoginWithPassword(LoginEmailAndPasswordDto loginEmailAndPassword);
        Task<ApplicationUsers> Register(RegisterDto register);
        Task<ApplicationUsers> UserExists(string email);
        Task<AccessToken> CreateToken(ApplicationUsers applicationUser);
    }
}
