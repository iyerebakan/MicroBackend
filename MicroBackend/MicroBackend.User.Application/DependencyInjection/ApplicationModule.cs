using Autofac;
using MicroBackend.Domain.Core.Interceptors;
using MicroBackend.User.Application.Interfaces;
using MicroBackend.User.Application.Services;
using MicroBackend.User.Data.Repository;

namespace MicroBackend.User.Application.DependencyInjection
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<UserRepository>();
            builder.RegisterType<RoleRepository>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.InterceptorModuleSelector(assembly);
        }
    }
}
