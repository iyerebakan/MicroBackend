using MicroBackend.Auth.Domain.Dtos;
using MicroBackend.Auth.Domain.Models;
using MicroBackend.Auth.JWT.Security.Token;
using MicroBackend.Domain.Core.Services.Interfaces;
using System.Threading.Tasks;

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
