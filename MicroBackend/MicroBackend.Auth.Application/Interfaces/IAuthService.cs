using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Domain.Core.Services.Interfaces;
using MicroBackend.Domain.Core.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroBackend.Auth.Domain.Models;

namespace MicroBackend.Auth.Application.Interfaces
{
    public interface IAuthService
    {
        Task<IServiceDataResult<ApplicationUsers>> ExternalLogin(LoginEmailDto loginEmail);
        Task<IServiceDataResult<ApplicationUsers>> LoginWithPassword(LoginEmailAndPasswordDto loginEmailAndPassword);
        Task<IServiceDataResult<ApplicationUsers>> Register(RegisterDto register);
        Task<IServiceDataResult<AccessToken>> CreateToken(ApplicationUsers applicationUser);
    }
}
