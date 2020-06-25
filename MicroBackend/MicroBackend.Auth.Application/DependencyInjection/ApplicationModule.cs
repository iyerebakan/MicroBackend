using Autofac;
using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Application.Services;
using MicroBackend.Auth.JWT.Security.Token;
using MicroBackend.Auth.JWT.Services.Jwt;

namespace MicroBackend.Auth.Application.DependencyInjection
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtService>().As<ITokenHelper>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
        }
    }
}
