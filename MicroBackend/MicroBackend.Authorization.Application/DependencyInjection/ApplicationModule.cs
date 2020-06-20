using Autofac;
using MicroBackend.Authorization.Application.DbHelper;
using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Application.Services;
using MicroBackend.Authorization.Data.Repository;
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
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<FormManager>().As<IFormService>().SingleInstance();

            builder.RegisterType<FolderManager>().As<IFolderService>().SingleInstance();

            builder.RegisterType<UserPrivilegesManager>().As<IUserPrivilegesService>().SingleInstance();

            builder.RegisterType<UserRepository>().WithParameter((pi, c) => pi.Name == "mongoHelper",
                                                                                       (pi, c) => c.ResolveNamed<MongoHelper>("MainDb"));

            builder.RegisterType<FolderRepository>().WithParameter((pi, c) => pi.Name == "mongoHelper",
                                                                                       (pi, c) => c.ResolveNamed<MongoHelper>("MainDb"));

            builder.RegisterType<FormRepository>().WithParameter((pi, c) => pi.Name == "mongoHelper",
                                                                                       (pi, c) => c.ResolveNamed<MongoHelper>("MainDb"));

            
        }
    }

}
