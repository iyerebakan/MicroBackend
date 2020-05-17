using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Application.Services;
using MicroBackend.Auth.JWT.Services.Jwt;
using MicroBackend.Domain.Core.Interceptors;
using MicroBackend.Domain.Core.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;

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
