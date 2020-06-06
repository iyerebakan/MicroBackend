using Autofac;
using MicroBackend.Authorization.Application.DbHelper;
using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Application.Services;
using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.DependencyInjection
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDbHelper>().Named<MongoHelper>("MainDb").InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().WithParameter((pi, c) => pi.Name == "mongoHelper",
                                                                                       (pi, c) => c.ResolveNamed<MongoHelper>("MainDb"));

            builder.RegisterType<FormManager>().As<IFormService>().WithParameter((pi, c) => pi.Name == "mongoHelper",
                                                                                       (pi, c) => c.ResolveNamed<MongoHelper>("MainDb"));

            builder.RegisterType<FolderManager>().As<IFolderService>().WithParameter((pi, c) => pi.Name == "mongoHelper",
                                                                                       (pi, c) => c.ResolveNamed<MongoHelper>("MainDb"));

            builder.RegisterType<UserPrivilegesManager>().As<IUserPrivilegesService>().WithParameter((pi, c) => pi.Name == "mongoHelper",
                                                                                       (pi, c) => c.ResolveNamed<MongoHelper>("MainDb"));

        }
    }

}
